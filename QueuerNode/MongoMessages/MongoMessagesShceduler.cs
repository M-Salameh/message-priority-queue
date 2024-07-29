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
        
        /// <summary>
        /// Connects to MongoDB to Store Messges and Set Things Up
        /// </summary>
        /// <param name="MyId"></param>
        /// <returns>string : ok if all goes well , otherwise something else</returns>
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
        
        /// <summary>
        /// insert a scheduled message in the mongodb 
        /// </summary>
        /// <param name="message"></param>
        /// <returns>string: ok or else</returns>
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

    }
}
