using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesConsumer.Extractor
{
    public class Extractor
    {
        private static string myConsumerID = "cons-1";

        private static int VeryLow = 1;
        private static int Low = 2;
        private static int Medium = 3;
        private static int High = 4;
        private static int VeryHigh = 5;

        private static int[] shares;

        private static int sms_rate = 100;

        private static IDatabase db = null;

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
           

        public static async Task<RedisValue> ProcessMessagesAsync(string stream, RedisValue id)
        {
            try
            {

                var messages = await db.StreamReadGroupAsync(stream, stream, myConsumerID, id, sms_rate);
                
                bool has_pending = true;

                if (messages.Length == 0)
                {
                    id = ">";
                    messages = await db.StreamReadGroupAsync(stream, stream , myConsumerID, id, sms_rate);
                    has_pending = false;
                }

                foreach (var entry in messages)
                {
                    Console.WriteLine("EXtraacting");

                    var messageId = entry.Id;

                    string? serializedMessage = entry.Values[0].Value.ToString();

                    Console.WriteLine(serializedMessage);

                    MessageDTO? message = JsonConvert.DeserializeObject<MessageDTO>(serializedMessage);

                    Console.WriteLine(message);

                    Writer.Writer.writeMessage(message);

                    db.StreamAcknowledge(stream, stream, messageId);

                    id = messageId;

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
    }
}
