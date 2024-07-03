using CSRedis;
using SimpleStreamConsumerTest;
using StackExchange.Redis;
using Newtonsoft.Json;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

var muxer = ConnectionMultiplexer.Connect("localhost");
var db = muxer.GetDatabase();

const string streamName = "5";


Dictionary<string, string> ParseResult(StreamEntry entry)
    => entry.Values.ToDictionary(x => x.Name.ToString(), x => x.Value.ToString());


int read = 0;
var readTask = Task.Run(async () =>
{
    string id = string.Empty;
    while (!token.IsCancellationRequested)
    {
        var messages = await db.StreamRangeAsync(streamName, "-", "+", 1, Order.Descending);
        foreach (var entry in messages)
        {
            // Get the message ID
            var messageId = entry.Id;

            // Access the message data (serialized JSON)
            string? serializedMessage = entry.Values.ToString();

            if (serializedMessage == null) continue;
            // Deserialize the JSON back to a Message object (if needed)
            MessageDTO? message = JsonConvert.DeserializeObject<MessageDTO>(serializedMessage);

            if (message == null) continue;
            // Process the message data (message.Text, message.Timestamp, etc.)
            Console.WriteLine($"Message ID: {messageId}, Text: {message.msgId}, tag: {message.tag}");
        }

        await Task.Delay(1000);
    }
});



tokenSource.CancelAfter(TimeSpan.FromSeconds(20));

await Task.WhenAll(readTask);










