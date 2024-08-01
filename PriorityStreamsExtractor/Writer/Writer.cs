using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityStreamsExtractor.Writer
{
    public class Writer
    {
        private static string Provider = "SYR";
        private static string Provider2 = "MTN";
        /// <summary>
        /// Stream Max Length Set to One Hundred Million which means stores only one 
        /// Hundred Million Messages in a stream, if more messages came , old ones are erased
        /// </summary>
        private static int StreamMaxLength = 100000000;

        private static IDatabase db = null;

        /// <summary>
        /// Get Redis DataBase To Which We Write Messages 
        /// in Order to Exrtact Them Later Easily, And Creates the Consumer Groups 
        /// for Each Provider so that consumers can work properly
        /// </summary>
        /// <param name="REDIS"></param>
        /// <returns>boolean: true if we can get database and all consumer groups are created</returns>
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



        /// <summary>
        /// Writes A Message after Casting the MessageDTO to the coherent stream which matches
        /// the name of the provider (MTN , SYR ..)
        /// this method keeps the streams sizes limited so no over storage happens
        /// </summary>
        /// <param name="message"></param>
        /// <param name="provider"></param>
        /// <returns>async task (bool): true if we could write the messages</returns>
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

    }
}
