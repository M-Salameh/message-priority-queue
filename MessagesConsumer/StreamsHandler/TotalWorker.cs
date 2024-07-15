using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesConsumer.StreamsHandler
{
    public class TotalWorker
    {
        public static Dictionary<string, RedisValue> lastId = new Dictionary<string, RedisValue>();
        public static void setAll(string RedisRead)
        {
            if (!Extractor.Extractor.setDatabase(RedisRead))
            {
                Console.WriteLine("ERROR : " + RedisRead);
                throw new Exception("ERROR : " + RedisRead);
            }
        }
        public static void work(string stream)
        {
            RedisValue id = (lastId.ContainsKey(stream) ? lastId[stream] : "0-0");

            RedisValue new_id = Extractor.Extractor.ProcessMessagesAsync(stream, id).Result;

            lastId[stream] = new_id;
        }
    }
}
