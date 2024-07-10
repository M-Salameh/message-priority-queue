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
        private static string Provider = "SYR";
        private static string groupName = "SYS_MSGS";
        private static string myConsumerID = "syr-1";

        private static int LOW = 1;
        private static int Medium = 2;
        private static int High = 3;

        private static int sms_rate = 10;

        private static IDatabase db = null;

        public static bool setDatabase(string REDIS , int _sms_rate)
        {
            try
            {
                var muxer = ConnectionMultiplexer.Connect(REDIS);
                db = muxer.GetDatabase();
                sms_rate = _sms_rate;
                //Console.WriteLine("Got DB");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static List<MessageDTO> ExtractMessages(int priority)
        {
            string stream = Provider + "_" + priority;
            
            if (priority == LOW)
            {
                return GetMessagesAsync(stream, 2).Result;
            }
            else if (priority == Medium)
            {
                return GetMessagesAsync(stream, 3).Result;
            }
            else if (priority == High)
            {
                return GetMessagesAsync(stream, 5).Result;
            }
            else
            {
                return new List<MessageDTO>();
            }
        }

        private static async Task<List<MessageDTO>> GetMessagesAsync(string stream , int count)
        {
            try
            {
                List<RedisValue> msgsID = new List<RedisValue>();

                List<MessageDTO> msgs = new List<MessageDTO>();
                var messages = await db.StreamReadGroupAsync(stream, groupName, myConsumerID, ">", count, true);

                foreach (var entry in messages)
                {
                    // Get the message ID
                    var messageId = entry.Id;
                    msgsID.Add(messageId);
                    Console.WriteLine(messageId);
                    // Access the message data (serialized JSON)
                    string? serializedMessage = entry.Values[0].Value.ToString();
                    Console.WriteLine(serializedMessage);

                    if (serializedMessage == null) continue;
                    // Deserialize the JSON back to a Message object (if needed)
                    MessageDTO? message = JsonConvert.DeserializeObject<MessageDTO>(serializedMessage);

                    if (message == null) continue;
                    msgs.Add(message);
                    // Process the message data 
                    Console.WriteLine($"Message ID: {messageId}, Text: {message.msgId}, tag: {message.tag}");
                }

                try
                {
                    await db.StreamDeleteAsync(stream, msgsID.ToArray());

                }
                catch (Exception ex)
                {
                    return await Task.FromResult(new List<MessageDTO>());   
                }
                return await Task.FromResult(msgs);
                
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new List<MessageDTO>());
            }

        }
    }
}
