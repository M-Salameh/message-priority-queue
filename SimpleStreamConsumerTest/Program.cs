using CSRedis;
using SimpleStreamConsumerTest;
using StackExchange.Redis;
using Newtonsoft.Json;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

string SYR = "localhost:6379";

var muxer = ConnectionMultiplexer.Connect(SYR);
var db = muxer.GetDatabase();

const string streamName5 = "5";
const string streamName = "SYR_3";
const string groupName = "SYS_MSGS";
const string myConsumerID = "some-id-2";

const int count = 100055566; // at most reads (count) messages from a stream

var readGroupTask2 = Task.Run(async () =>
{
    string id = string.Empty;
    while (!token.IsCancellationRequested)
    {
        ///var messages = await db.StreamReadGroupAsync(streamName, groupName, myConsumerID, "$", count);
        var messages =  db.StreamPendingMessages(streamName, groupName , count , myConsumerID);


        //Console.WriteLine(messages.Length);


        foreach (var msg in messages)
        {
            Console.WriteLine(msg);
            // Get the message ID
            /*var messageId = entry.Id;
            Console.WriteLine(messageId);
            // Access the message data (serialized JSON)
            string? serializedMessage = entry.Values[0].Value.ToString();
            Console.WriteLine(serializedMessage);

            if (serializedMessage == null) continue;
            // Deserialize the JSON back to a Message object (if needed)
            MessageDTO? message = JsonConvert.DeserializeObject<MessageDTO>(serializedMessage);

            if (message == null) continue;
            // Process the message data 
            Console.WriteLine($"Message ID: {messageId}, Text: {message.msgId}, tag: {message.tag}");
            */
        }

        await Task.Delay(1000);
    }
});




tokenSource.CancelAfter(TimeSpan.FromSeconds(300));

await Task.WhenAll(readGroupTask2);










