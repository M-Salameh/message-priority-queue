using Newtonsoft.Json;
using PriorityStreamsExtractor.Initializer;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityStreamsExtractor.Extractor
{
    public class Extractor
    {
        private static string groupName = ReadRedisInfoParser.group_name;
        private static string myConsumerID = ReadRedisInfoParser.consumer_id;

        private static int VeryLow = 1;
        private static int Low = 2;
        private static int Medium = 3;
        private static int High = 4;
        private static int VeryHigh = 5;

        private static Dictionary<string, int[]> shares = new Dictionary<string, int[]>();

        private static Dictionary<string, int> sms_rate = new Dictionary<string, int>();

        private static IDatabase db = null;

        /// <summary>
        /// Gets Redis DataBase of which we shall consume messages while read and it is the same redis that
        /// Scheduler Nodes Writes To
        /// by associating number of messages limit to read to each priority which are precentage of sms_rate
        /// </summary>
        /// <param name="REDIS"></param>
        /// <returns>boolean : if we could connect to database or not</returns>
        public static bool setDatabase(string REDIS)
        {            
            try
            {
                var muxer = ConnectionMultiplexer.Connect(REDIS);
                db = muxer.GetDatabase();
                sms_rate[ProvidersInfoParser.Syriatel] = ProvidersInfoParser.syr_rate;
                sms_rate[ProvidersInfoParser.MTN] = ProvidersInfoParser.mtn_rate;
                //Console.WriteLine("Got DB");
                setShares();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static void setShares()
        {
            foreach (KeyValuePair <string,int> entry in sms_rate)
            {
                string provider = entry.Key;
                int rate = entry.Value;
                int sum = 0;
                shares[provider] = new int[VeryHigh + 1];
                sum += shares[provider][VeryHigh] = (35 * rate) / 100;
                sum += shares[provider][High] = (30 * rate) / 100;
                sum += shares[provider][Medium] = (20 * rate) / 100;
                sum += shares[provider][Low] = (10 * rate) / 100;
                sum += shares[provider][VeryLow] = (5 * rate) / 100;
                shares[provider][VeryHigh] += ((rate - sum) > 0 ? rate - sum : 0);
            }
        }
        
        /// <summary>
        /// Reads Messages from Stream starting with the id provided (its track is kept by the StreamsHandler.TotalWorker)
        /// After Extracting Messages they are prcocessed and Written through the WRITER to 
        /// another Redis where MessageConsumer Services Reads them, then Ack Messages after Writing Them
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<RedisValue> ProcessMessagesAsync(string stream, RedisValue id)
        {
            try
            {
                int priority = getPriority(stream);

                string write_stream = getWriteStream(stream);

                int count = shares[write_stream][priority];

                var messages = await db.StreamReadGroupAsync(stream, groupName, myConsumerID, id, count);
                
                bool has_pending = true;

                if (messages.Length == 0)
                {
                    id = ">";
                    messages = await db.StreamReadGroupAsync(stream, groupName, myConsumerID, id, count);
                    has_pending = false;
                }

                foreach (var entry in messages)
                {
                    Console.WriteLine("EXtraacting");

                    var messageId = entry.Id;

                    //Console.WriteLine(messageId);

                    string? serializedMessage = entry.Values[0].Value.ToString();

                    Console.WriteLine(serializedMessage);

                    MessageDTO? message = JsonConvert.DeserializeObject<MessageDTO>(serializedMessage);

                    Console.WriteLine(message);

                    bool success = await Writer.Writer.writeMessageAsync(message, write_stream);

                    if (success)
                    {
                        Console.WriteLine("Success");
                        db.StreamAcknowledge(stream, groupName, messageId);
                        id = messageId;
                    }
                    else
                    {
                        has_pending = true;
                        break;
                    }

                }

                if (!has_pending) id = ">";

                return await Task.FromResult(id);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while Reading or Acking");
                return await Task.FromResult(id);
            }

        }

        private static string getWriteStream(string stream)
        {
            string[] write_prio = stream.Split("_");
            return write_prio[0];
        }

        private static int getPriority(string stream)
        {
            string[] write_prio = stream.Split("_");
            return int.Parse(write_prio[1]);
        }
    }
}
