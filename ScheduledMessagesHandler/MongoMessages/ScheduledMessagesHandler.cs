using MongoDB.Bson;
using MongoDB.Driver;
using ScheduledMessagesHandler;
using ScheduledMessagesHandler.Initializer;
using ScheduledMessagesHandler.RedisQueuer;

namespace ScheduledMessagesHandler.MongoMessages
{
    public class ScheduledMessagesHandler
    {
        private string MongoURL = MessagesMongoDBParser.connection;
        private string DataBaseName = MessagesMongoDBParser.database;
        private string myCollection = MessagesMongoDBParser.collection;
        
        //private  IMongoCollection<BsonDocument> collection;
        public string ConnectionError = "Error Connecting to MongoDB on : " + MessagesMongoDBParser.connection;
        private string NotTaken = "Not-Taken";
        private string Pending = "Pending";
        private string Acked = "Acked";
        private int limit = 100000;
        /// <summary>
        /// Connects to MongoDB to Store Messges and Set Things Up
        /// </summary>
        /// <param name="MyId"></param>
        /// <returns>string : ok if all goes well , otherwise something else</returns>
        /*public  string init()
        {
            try
            {
                var client = new MongoClient(MongoURL);

                var database = client.GetDatabase(DataBaseName);

                collection = database.GetCollection<BsonDocument>(myCollection);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }*/

        /// <summary>
        /// extract dued scheduled messages cautiously and write them to Redis Stream by Priority
        /// </summary>
        public void getDuedMessagesAndQueue()
        {
            bool thereArePending = true;
            while (true)
            {
                if (thereArePending)
                {
                    thereArePending = getBulkMessages(Pending);
                }

                if (!thereArePending)
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
        private bool getBulkMessages(string status)
        {
            IMongoCollection<BsonDocument> collection = MongoSettingsInitializer.collection;
            MessageQueues messageQueues = new MessageQueues();
            var specificTime = DateTime.UtcNow;

            var filter = Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.Lte("timestamp", specificTime),
                        Builders<BsonDocument>.Filter.Eq("status", status)
                        );

            var sort = Builders<BsonDocument>.Sort.Ascending("timestamp");

            var docs = collection.Find(filter)
                                 .Limit(limit)
                                 .Sort(sort)
                                 .ToList<BsonDocument>();

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
                string result = messageQueues.addMessage(message);
                if (!result.Equals(messageQueues.RedisConnectionError))
                {
                    collection.UpdateOne(_filter, updateAck);
                    //Console.WriteLine(message);
                }

            }

            return true;

        }

        private MessageDTO getMessage(BsonDocument doc)
        {
            MessageDTO message = new MessageDTO();
            message.clientID = (string)doc["sender"];
            message.text = (string)doc["content"];
            message.tag = (string)doc["tag"];
            message.localPriority = (int)doc["priority"];
            message.phoneNumber = (string)doc["phone-number"];
            message.msgId = (string)doc["msg-id"];
            message.apiKey = (string)doc["api-key"];
            DateTime dd = (DateTime)doc["timestamp"];
            Console.WriteLine(dd);
            message.year = dd.Year;
            message.month = dd.Month;
            message.hour = dd.Hour;
            message.day = dd.Day;
            message.minute = dd.Minute;
            //message.year = message.month = message.day = message.hour = message.minute = 0;
            return message;
        }
    }
}
