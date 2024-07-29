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
        private static string Provider2 = "MTN";
        private static int StreamMaxLength = 100000000;

        private static IDatabase db = null;

        public static bool setDatabase(string REDIS)
        {
            try
            {
                var muxer = ConnectionMultiplexer.Connect(REDIS);
                db = muxer.GetDatabase();
                return createConsumerGroup();
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
                bool k1 = db.StreamCreateConsumerGroup
                            (
                                Provider,
                                Provider,
                                0,
                                true
                            );

                bool k2 = db.StreamCreateConsumerGroup
                        (
                            Provider2,
                            Provider2,
                            0,
                            true
                        );
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return (ex.Message.Contains("already exists", StringComparison.OrdinalIgnoreCase));
            }
        }

        public static async Task<bool> writeMessageAsync(MessageDTO message, string provider)
        {
            try
            {
                var serializedMessage = JsonConvert.SerializeObject(message);

                Console.WriteLine("Writing  : " + message);

                var temp = await db.StreamAddAsync
                        (provider,
                                new NameValueEntry[]
                                    {
                                new NameValueEntry("message", serializedMessage)
                                    },
                                null,
                                StreamMaxLength,
                                true
                        );
                /*var temp = await db.StreamAddAsync
                        (provider,
                                new NameValueEntry[]
                                    {
                                new NameValueEntry("message", serializedMessage)
                         );*/

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while Writing");
                return await Task.FromResult(false);

            }

        }

    
        public static void trimStream(string stream , RedisValue id)
        {
            
        }
    }
}
