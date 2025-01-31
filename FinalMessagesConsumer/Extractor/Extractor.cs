﻿using FinalMessagesConsumer.Initializer;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMessagesConsumer.Extractor
{
    public class Extractor
    {
        private static string myConsumerID = ReadRedisInfoParser.consumer_id;

        private static IDatabase db = null;
        
        private static Dictionary<string, int> _sms_rate = new Dictionary<string, int>();
        /// <summary>
        /// Gets Redis DataBase of which we shall consume messages while read
        /// by sms_rate messages per second
        /// </summary>
        /// <param name="REDIS"></param>
        /// <param name="_sms_rate"></param>
        /// <returns>boolean : if we could connect to database or not</returns>
        public static bool setDatabase(string REDIS)
        {            
            try
            {
                var muxer = ConnectionMultiplexer.Connect(REDIS);
                db = muxer.GetDatabase();
                _sms_rate[ProvidersInfoParser.Syriatel] = ProvidersInfoParser.syr_rate;
                _sms_rate[ProvidersInfoParser.MTN] = ProvidersInfoParser.mtn_rate;

                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return false;
            }
        }
           
        /// <summary>
        /// Reads Messages from Stream starting with the id provided (its track is kept by the TotalWorker)
        /// After Extracting Messages they are prcocessed and Written throgh the WRITER 
        /// then Acked
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<RedisValue> ProcessMessagesAsync(string stream, RedisValue id)
        {
            try
            {
                int sms_rate = _sms_rate[stream];
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
                    //Console.WriteLine("EXtraacting");

                    var messageId = entry.Id;

                    string? serializedMessage = entry.Values[0].Value.ToString();

                    //Console.WriteLine(serializedMessage);

                    MessageDTO? message = JsonConvert.DeserializeObject<MessageDTO>(serializedMessage);

                   // Console.WriteLine(message);

                    Writer.Writer.writeMessage(message);

                    db.StreamAcknowledge(stream, stream, messageId);

                    id = messageId;

                }

                if (!has_pending) id = ">";

                return await Task.FromResult(id);

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error while Reading or Acking");
                //Console.WriteLine(ex.Message);
                return await Task.FromResult(id);
            }

        }
    
    }
}
