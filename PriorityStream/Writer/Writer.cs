using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityStream.Writer
{

    public class Writer
    {
        private static string Provider = "SYR";

        private static IDatabase db = null;

        public static bool setDatabase(string REDIS)
        {
            try
            {
                var muxer = ConnectionMultiplexer.Connect(REDIS);
                db = muxer.GetDatabase();
                return 
                createConsumerGroup();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static bool createConsumerGroup()
        {
            try
            {
                bool k1 = db.StreamCreateConsumerGroup(Provider,
                        Provider,
                        "$",
                        true);
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return (ex.Message.Contains("already exists" , StringComparison.OrdinalIgnoreCase));
            }
        }

        public static void writeMessages(List<MessageDTO> messages)
        {
            foreach (var message in messages)
            {
                var serializedMessage = JsonConvert.SerializeObject(message);
                db.StreamAddAsync
                        (Provider,
                                new NameValueEntry[]
                                    {
                                    new NameValueEntry("message", serializedMessage)
                                    });
            }
        }

    }
}
