using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityStream.Extractor
{
    public class Extractor
    {
        private static string groupName = "SYS_MSGS";
        private static string myConsumerID = "cons-1";

        private static int VeryLow = 1;
        private static int Low = 2;
        private static int Medium = 3;
        private static int High = 4;
        private static int VeryHigh = 5;

        private static int[] shares;

        private static int sms_rate = 100;

        private static IDatabase db = null;

        /// <summary>
        /// Gets Redis DataBase of which we shall consume messages while read and it is the same redis that
        /// Scheduler Nodes Writes To
        /// by associating number of messages limit to read to each priority which are precentage of sms_rate
        /// </summary>
        /// <param name="REDIS"></param>
        /// <param name="_sms_rate"></param>
        /// <returns>boolean : if we could connect to database or not</returns>
        public static bool setDatabase(string REDIS , int _sms_rate = 100)
        {            
            try
            {
                var muxer = ConnectionMultiplexer.Connect(REDIS);
                db = muxer.GetDatabase();
                sms_rate = _sms_rate;
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
            shares = new int[VeryHigh + 1];
            int sum = 0;
            sum += shares[VeryHigh] = (35 * sms_rate) / 100;
            sum += shares[High] = (30 * sms_rate) / 100;
            sum += shares[Medium] = (20 * sms_rate) / 100;
            sum += shares[Low] = (10 * sms_rate) / 100;
            sum += shares[VeryLow] = (5 * sms_rate) / 100;

            shares[VeryHigh] += ((sms_rate - sum) > 0 ? sms_rate - sum : 0);
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

                int count = shares[priority];

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
                        db.StreamAcknowledge(stream, stream, messageId);
                        id = messageId;
                    }
                    else
                    {
                        has_pending = true;
                        break;
                    }

                }

                Writer.Writer.trimStream(stream, id);

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
