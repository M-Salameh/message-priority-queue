using MongoDB.Bson;
using MongoDB.Driver;
using Validator.Initializer;

namespace Validator.MongoMessages
{
    public class MongoSettingsInitializer
    {
        private static string MongoURL = AccountsDBParser.connection;
        private static string DataBaseName = AccountsDBParser.DBName;
        private static string myCollection = AccountsDBParser.collection;

        public static IMongoCollection<BsonDocument> collection;
        public static string ConnectionError = "Error Connecting to MongoDB on : " + MongoURL;
        

        /// <summary>
        /// Connects to MongoDB to Store Messges and Set Things Up
        /// </summary>
        /// <returns>string : ok if all goes well , otherwise something else</returns>
        public static string init()
        {
            var client = new MongoClient(MongoURL);

            var database = client.GetDatabase(DataBaseName);

            collection = database.GetCollection<BsonDocument>(myCollection);

            var keys = Builders<BsonDocument>.IndexKeys.Ascending("api-key").Ascending("client-id");

            var indexOptions = new CreateIndexOptions { Background = true };

            var indexModel = new CreateIndexModel<BsonDocument>(keys, indexOptions);

            collection.Indexes.CreateOne(indexModel);

            return "ok";
        }
    }
}
