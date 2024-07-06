using CSRedis;
using SimpleStreamConsumerTest;
using StackExchange.Redis;
using Newtonsoft.Json;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

string SYR = "localhost:6374";
//string MTN = "localhost:6373";

var muxer = ConnectionMultiplexer.Connect(SYR);
var db = muxer.GetDatabase();

const string streamName5 = "5";
const string streamName2 = "2";
const string groupName = "SYS_MSGS";
const string myConsumerID = "some-id";

const int count = 100055566; // at most reads (count) messages from a stream

/*var readTask = Task.Run(async () =>
{
    string id = string.Empty;
    while (!token.IsCancellationRequested)
    {
        var messages = await db.StreamRangeAsync(streamName, "-", "+", count, Order.Descending);
        
        Console.WriteLine(messages.Length);

        foreach (var entry in messages)
        {
            // Get the message ID
            var messageId = entry.Id;
            Console.WriteLine(messageId);
            // Access the message data (serialized JSON)
            string? serializedMessage = entry.Values[0].Value.ToString();
            Console.WriteLine(serializedMessage);

            if (serializedMessage == null) continue;
            // Deserialize the JSON back to a Message object (if needed)
            MessageDTO? message = JsonConvert.DeserializeObject<MessageDTO>(serializedMessage);

            if (message == null) continue;
            // Process the message data (message.Text, message.Timestamp, etc.)
            Console.WriteLine($"Message ID: {messageId}, Text: {message.msgId}, tag: {message.tag}");
        }

        await Task.Delay(1000);
    }
});*/

var readGroupTask2 = Task.Run(async () =>
{
    string id = string.Empty;
    while (!token.IsCancellationRequested)
    {
        var messages = await db.StreamReadGroupAsync(streamName2, groupName, myConsumerID, ">", count);

        //Console.WriteLine(messages.Length);

        foreach (var entry in messages)
        {
            // Get the message ID
            var messageId = entry.Id;
            Console.WriteLine(messageId);
            // Access the message data (serialized JSON)
            string? serializedMessage = entry.Values[0].Value.ToString();
            Console.WriteLine(serializedMessage);

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

var readGroupTask5 = Task.Run(async () =>
{
    string id = string.Empty;
    while (!token.IsCancellationRequested)
    {
        var messages = await db.StreamReadGroupAsync(streamName5, groupName, myConsumerID, ">", count);

        //Console.WriteLine(messages.Length);

        foreach (var entry in messages)
        {
            // Get the message ID
            var messageId = entry.Id;
            Console.WriteLine(messageId);
            // Access the message data (serialized JSON)
            string? serializedMessage = entry.Values[0].Value.ToString();
            Console.WriteLine(serializedMessage);

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



tokenSource.CancelAfter(TimeSpan.FromSeconds(300));

await Task.WhenAll(readGroupTask5, readGroupTask2);










