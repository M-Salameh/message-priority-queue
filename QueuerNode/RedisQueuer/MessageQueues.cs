﻿using Newtonsoft.Json;
using StackExchange.Redis;
using Steeltoe.Discovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerNode.RedisQueuer
{
    public class MessageQueues
    {
        private static string RedisURL = "localhost:6379";
        public static string RedisConnectionError = "Error Writing to Redis";

        private static string Syriatel = "SYR";
        private static string MTN = "MTN";

        private static int LEVELS = 6;
        private static int StreamMaxLength = 100000000;
        private static IDatabase db = null;

        /// <summary>
        /// Connects to Redis Stream With Streams for Each Priority and create consuming groups
        /// if not created
        /// </summary>
        public static void init()
        {

            var redis = ConnectionMultiplexer.Connect(RedisURL);
            db = redis.GetDatabase();
            for (int i=1; i < LEVELS; i++)
            {
                try
                {
                    bool k1 = db.StreamCreateConsumerGroup(Syriatel+"_"+i.ToString(),
                        "SYS_MSGS",
                        0,
                        true);

                    bool k2 = db.StreamCreateConsumerGroup(MTN+"_"+i.ToString(),
                        "SYS_MSGS",
                        0,
                        true);


                    if (k1 && k2)
                    {
                        Console.WriteLine("OK");
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
           
        }


        /// <summary>
        /// Add a Message to the According Redis Stream 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string addMessage(Message message)
        {
            string id = "Error";
            string temp = string.Empty;
           
            var resid = addMessageRedisAsync(message, RedisURL);
            temp = resid.Result;
            
            if (temp.Equals(RedisConnectionError))
            {
                return RedisConnectionError;
            }
            id = message.Tag + ":" + message.LocalPriority + ":" + temp;
            //id = Guid.NewGuid().ToString();
            return id;
        }
       
        
        private static async Task<string> addMessageRedisAsync(Message message, string URL)
        {
            try
            {
                string tag = getTag(ref message);

                string streamName = tag + "_" + message.LocalPriority.ToString();

                Console.WriteLine("stream name  = " + streamName);

                var serializedMessage = JsonConvert.SerializeObject(message);

                Console.WriteLine("Sending to stream : " + streamName);

                var messageId = await db.StreamAddAsync
                                    (streamName,
                                          new NameValueEntry[]
                                             {
                                                 new NameValueEntry("message", serializedMessage)
                                             },
                                          null,
                                          StreamMaxLength,
                                          true        
                                     );


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

        private static string getTag (ref Message message)
        {
            
            if(message.Tag.Contains(Syriatel, StringComparison.OrdinalIgnoreCase))
            {
                return Syriatel;
            }

            else
            {
                return MTN;
            }
        }
    }
}
