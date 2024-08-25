using MongoDB.Bson;
using MongoDB.Driver;
using Scheduler.Initializer;
using SchedulerNode;
using SchedulerNode.RedisQueuer;
using SchedulerNode.Services;

namespace Scheduler.MongoMessages
{
    public class MongoMessagesShceduler
    {
        private string MongoURL = MessagesMongoDBParser.connection;
        private string DataBaseName = MessagesMongoDBParser.database;
        private string myCollection = MessagesMongoDBParser.collection;
        
        //private  IMongoCollection<BsonDocument> collection;
        public string ConnectionError = "Error Connecting to MongoDB on : " + MessagesMongoDBParser.connection;
        private string NotTaken = "Not-Taken";
        
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
        /// insert a scheduled message in the mongodb 
        /// </summary>
        /// <param name="message"></param>
        /// <returns>string: ok or else</returns>
        public  string insertMessage(ref Message message)
        {
            try 
            {
                IMongoCollection<BsonDocument> collection = MongoSettingsInitializer.collection;

                DateTime date = new DateTime(message.Year, message.Month, message.Day, message.Hour, message.Minute, 2);
                //Console.WriteLine(date);
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
