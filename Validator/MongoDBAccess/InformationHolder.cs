using MongoDB.Bson;
using MongoDB.Driver;
using Validator.Initializer;
using Validator.MongoMessages;

namespace Validator.MongoDBAccess
{
    public class InformationHolder
    {
        public string OK = "ok";
        public string DBError = "Could Not Connect To Data Base";
        public string Error = "Illegal Message";
        public string checkMessage(MessageMetaData metaData)
        {
            string apiKey = metaData.ApiKey;
            string clientId = metaData.ClientID;
            string tag = metaData.Tag;
            IMongoCollection<BsonDocument> collection = MongoSettingsInitializer.collection;

            var filter = Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.Eq("api-key", apiKey),
                        Builders<BsonDocument>.Filter.Eq("client-id", clientId)
                        );

            try
            {
                var docs = collection.Find(filter).ToList<BsonDocument>();

                if (docs.Count == 0)
                {
                    return Error;
                }

                foreach (var doc in docs)
                {
                    var tags = (string)doc["providers"];
                    if (tags.Contains(tag, StringComparison.OrdinalIgnoreCase))
                    {
                        return OK;
                    }
                }

                return Error;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DBError;
            }
        }
    }
}
