using Newtonsoft.Json;
using StackExchange.Redis;
using Steeltoe.Discovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuerNode.RedisQueuer
{
    public class MessageQueues
    {
        private static string MTNRedisURL = "localhost:6373";
        private static string SYRRedisURL = "localhost:6374";
        public static string RedisConnectionError = "Error Writing to Redis";

        private static string Syriatel = "SYR";
        private static string MTN = "MTN";

        private static int LEVELS = 6;

        public static void init()
        {
            Console.WriteLine("Initing");
           /* var redis = ConnectionMultiplexer.Connect(SYRRedisURL);
            var db = redis.GetDatabase();
            for (int i=0; i < LEVELS; i++)
            {
               bool k = db.StreamCreateConsumerGroup(i.ToString(),
                   "SYS_MSGS", 
                   "$",
                   true);
                if(k)
                {
                    Console.WriteLine("OK");
                }
            }
            redis = ConnectionMultiplexer.Connect(MTNRedisURL);
            db = redis.GetDatabase();
            for (int i = 0; i < LEVELS; i++)
            {
                bool k = db.StreamCreateConsumerGroup(i.ToString(),
                    "SYS_MSGS",
                    "$",
                    true);
            }*/
        }
        public static string addMessage(Message message , IDiscoveryClient discoveryClient)
        {
            string id = "Error";
            string temp = string.Empty;
            if (message.Tag.Contains(Syriatel, StringComparison.OrdinalIgnoreCase))
            {
                // get url using discovery client
                var resid = addMessageRedisAsync(message, SYRRedisURL);    
                temp = resid.Result;
            }

            else if (message.Tag.Contains(MTN, StringComparison.OrdinalIgnoreCase))
            {
                var resid = addMessageRedisAsync(message, MTNRedisURL);
                temp = resid.Result;
            }

            if (temp.Equals(RedisConnectionError))
            {
                return RedisConnectionError;
            }
            id = message.Tag + ":" + message.LocalPriority + ":" + temp;
            return id;
        }
       
        
        private static async Task<string> addMessageRedisAsync(Message message, string URL)
        {
            try
            {
                var redis = ConnectionMultiplexer.Connect(URL);

                string streamName = message.LocalPriority.ToString();
                Console.WriteLine("stream name  = " + streamName);

                var db = redis.GetDatabase();

                var serializedMessage = JsonConvert.SerializeObject(message);

                Console.WriteLine("Sending to stream : " + streamName);

                //var messageId = await db.StreamAddAsync(streamName, new NameValueEntry[] { }, serializedMessage);

                var messageId = await db.StreamAddAsync
                                    (streamName,
                                          new NameValueEntry[]
                                             {
                                                 new NameValueEntry("message", serializedMessage)
                                             });


                Console.WriteLine("Done Sending to stream : " + streamName);
                Console.WriteLine("Stream msg id = " + messageId);
                //var messageId = "YES";
                return messageId.ToString();
            }

            catch (Exception ex)
            {
                return await Task.FromResult(RedisConnectionError);
            }
        }
    }
}
