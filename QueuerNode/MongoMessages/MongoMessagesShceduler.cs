using MongoDB.Bson;
using MongoDB.Driver;
using SchedulerNode;
using SchedulerNode.RedisQueuer;
using SchedulerNode.Services;

namespace Scheduler.MongoMessages
{
    public class MongoMessagesShceduler
    {
        private static string MONGODB = "mongodb://127.0.0.1:27017";
        private static string DataBaseName = "scheduled-messages";
        private static string myCollection = "messages";
        public static string ConnectionError = "Error Connecting to MongoDB on : " + MONGODB;
        private static IMongoCollection<BsonDocument> collection;

        private static string NotTaken = "Not-Taken";
        
        public static string init(string MyId)
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
        
        public static string insertMessage(ref Message message)
        {
            try 
            {

                DateTime date = new DateTime(message.Year, message.Month, message.Day, message.Hour, message.Minute, 2);
                var document = new BsonDocument
                    {
                        { "sender", message.ClientID},
                        { "timestamp", date },
                        { "content", message.Text},
                        { "tag" , message.Tag },
                        { "priority"  , message.LocalPriority},
                        { "msg-id"  , message.MsgId},
                        { "phone-number" , message.PhoneNumber },
                        { "api-key" , message.ApiKey },
                        { "status" , NotTaken }
                    };
                collection.InsertOne(document);
                return "OK";
            }
            catch (Exception ex)
            {
                return ConnectionError;
            }
        }


        /*
        //getBulkOfMessages where their Oks is MyId (not Acked)
        //queue them
        //then ack them (ok = Acked)
        //when finished get Oks = 0 and put their Ok as MyId
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
                Task.Delay(5000);
            }
            
        }

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
            UpdateDefinition<BsonDocument> updateAcj = Builders<BsonDocument>.Update.Set("status", Acked);
            foreach (var doc in docs)
            {
                Message message = getMessage(doc);
                var _filter =  Builders<BsonDocument>.Filter.Eq("_id", doc["_id"]);
                collection.UpdateOne(_filter, updatePending);
                
            }

            return true;
            
        }

        private static Message getMessage(BsonDocument doc)
        {
            Message message = new Message();
            message.ClientID = (string)doc["sender"];
            message.Text = (string)doc["content"];
            message.Tag = (string)doc["tag"];
            message.LocalPriority = (int)doc["priority"];
            message.PhoneNumber = (string)doc["phone-number"];
            message.MsgId = (string)doc["msg-id"];
            message.ApiKey = (string)doc["api-key"];
            message.Year = message.Month = message.Day = message.Hour = message.Minute = 0;
            return message;
        }
        */
    }
}
