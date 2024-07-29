using MongoDB.Bson;
using MongoDB.Driver;
using ScheduledMessagesHandler.RedisQueuer;

namespace ScheduledMessagesHandler.MongoMessages
{
    public class MongoMessagesShceduler
    {
        private static string MONGODB = "mongodb://127.0.0.1:27017";
        private static string DataBaseName = "scheduled-messages";
        private static string myCollection = "messages";
        public static string ConnectionError = "Error Connecting to MongoDB on : " + MONGODB;
        private static IMongoCollection<BsonDocument> collection;
        private static string Pending = "Pending";
        private static string Acked = "Acked";
        //this NotTaken here must be the same of NotTaken in scheduler
        private static string NotTaken = "Not-Taken";
        private static int limit = 100000;
        
        /// <summary>
        /// Connects to MongoDB Where Scheduled Messages Are Stored by The Scheduler Service
        /// </summary>
        /// <returns>string : ok if every thing goes fine</returns>
        public static string init()
        {
            try
            {
                var client = new MongoClient(MONGODB);

                var database = client.GetDatabase(DataBaseName);

                collection = database.GetCollection<BsonDocument>(myCollection);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        /// <summary>
        /// extract dued scheduled messages cautiously and write them to Redis Stream by Priority
        /// </summary>
        public static void getDuedMessagesAndQueue()
        {
            bool thereArePending = true;
            while (true)
            {
                if (thereArePending)
                {
                   thereArePending = getBulkMessages(Pending);  
                }

                if (! thereArePending)
                {
                    thereArePending = getBulkMessages(NotTaken);
                }
                
            }
            
        }

        /// <summary>
        /// extract dued messages with status as passed and process them 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private static bool getBulkMessages(string status)
        {
            var specificTime = DateTime.UtcNow;

            var filter = Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.Lte("timestamp", specificTime),
                        Builders<BsonDocument>.Filter.Eq("status", status)
                        );

            var docs = collection.Find(filter).Limit(limit).ToList<BsonDocument>();
            
            if (docs.Count == 0)
            {
                return false;
            }


            UpdateDefinition<BsonDocument> updatePending = Builders<BsonDocument>.Update.Set("status", Pending);
            UpdateDefinition<BsonDocument> updateAck = Builders<BsonDocument>.Update.Set("status", Acked);
            foreach (var doc in docs)
            {
                MessageDTO message = getMessage(doc);
                var _filter = Builders<BsonDocument>.Filter.Eq("_id", doc["_id"]);
                if (!status.Equals(Pending))
                {
                    collection.UpdateOne(_filter, updatePending);
                }
                string result = MessageQueues.addMessage(message);
                if (!result.Equals (MessageQueues.RedisConnectionError))
                {
                    collection.UpdateOne(_filter, updateAck);
                    //Console.WriteLine(message);
                }
                
            }

            return true;
            
        }

        private static MessageDTO getMessage(BsonDocument doc)
        {
            MessageDTO message = new MessageDTO();
            message.clientID = (string)doc["sender"];
            message.text = (string)doc["content"];
            message.tag = (string)doc["tag"];
            message.localPriority = (int)doc["priority"];
            message.phoneNumber = (string)doc["phone-number"];
            message.msgId = (string)doc["msg-id"];
            message.apiKey = (string)doc["api-key"];
            message.year = message.month = message.day = message.hour = message.minute = 0;
            return message;
        }
    }
}
