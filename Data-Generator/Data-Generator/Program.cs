using MongoDB.Bson;
using MongoDB.Driver;

class Program
{
    static void Main(string[] args)
    {
        var client = new MongoClient("mongodb://localhost:27020");

        var database = client.GetDatabase("AccountsDB");

        var collection = database.GetCollection<BsonDocument>("Accounts");

        var keys = Builders<BsonDocument>.IndexKeys.Ascending("api-key").Ascending("client-id");

        var indexOptions = new CreateIndexOptions { Background = true };

        var indexModel = new CreateIndexModel<BsonDocument>(keys, indexOptions);

        collection.Indexes.CreateOne(indexModel);


        for (char c = 'a'; c <= 'z'; c++)
        {
            for (int i = 1; i <= 10; i++)
            {
                string x = c.ToString();
                string y = i.ToString();
                var document = new BsonDocument
                    {

                        { "api-key", x },
                        { "client-id", y },
                        { "providers", "mtn , syr"},
                    };

                collection.InsertOne(document);
            }
        }

        // Insert the document into the collection

        Console.WriteLine("Document inserted successfully.");

        while (true)
        {
            string apikey, tag;
            string number;
            Console.WriteLine("Enter : api then number then tag");
            apikey = Console.ReadLine();
            number = Console.ReadLine();
            tag = Console.ReadLine();

            var filter = Builders<BsonDocument>.Filter.And(
                               Builders<BsonDocument>.Filter.Eq("api-key", apikey),
                               Builders<BsonDocument>.Filter.Eq("client-id", number)
                               );


            var docs = collection.Find(filter).ToList<BsonDocument>();


            if (docs.Count == 0)
            {
                Console.WriteLine("NO");
            }
            bool ok = false;
            foreach (var doc in docs)
            {
                var tags = (string)doc["providers"];
                if (tags.Contains(tag, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Yes for " + tag + " , " + apikey + " , " + number);
                    ok = true;
                }
            }
            if (!ok)
            {
                Console.WriteLine("NO");
            }

        }

    }
}