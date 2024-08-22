using MongoDB.Bson;
using MongoDB.Driver;
using ScheduledMessagesHandler.Initializer;

namespace ScheduledMessagesHandler.MongoMessages
{
    public class MongoSettingsInitializer
    {
        private static string MongoURL = MessagesMongoDBParser.connection;
        private static string DataBaseName = MessagesMongoDBParser.database;
        private static string myCollection = MessagesMongoDBParser.collection;

        public static IMongoCollection<BsonDocument> collection;
        public static string ConnectionError = "Error Connecting to MongoDB on : " + MongoURL;
        private static string NotTaken = "Not-Taken";

        /// <summary>
        /// Connects to MongoDB to Store Messges and Set Things Up
        /// </summary>
        /// <param name="MyId"></param>
        /// <returns>string : ok if all goes well , otherwise something else</returns>
        public static string init()
        {
            try
            {
                var client = new MongoClient(MongoURL);

                var database = client.GetDatabase(DataBaseName);

                collection = database.GetCollection<BsonDocument>(myCollection);

                var keys = Builders<BsonDocument>.IndexKeys.Ascending("timestamp").Ascending("status");

                var indexOptions = new CreateIndexOptions { Background = true };

                var indexModel = new CreateIndexModel<BsonDocument>(keys, indexOptions);

                collection.Indexes.CreateOne(indexModel);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
