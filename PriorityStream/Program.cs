using CSRedis;
using StackExchange.Redis;
using Newtonsoft.Json;
using PriorityStream;
using PriorityStream.Extractor;
using PriorityStream.Writer;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

string RedisRead = "localhost:6379";
string RedisWrite = "localhost:6379";

int[] levels = new int[] { 1, 2, 3 };

int sms_rate = 10;

if (!Extractor.setDatabase(RedisRead , sms_rate)   )
{
    Console.WriteLine("Error Connecting to Redis Read on host :  " + RedisRead);
    return;
}

if (!Writer.setDatabase(RedisWrite))
{
    Console.WriteLine("Error Connecting to Redis Write on host :  " + RedisWrite);
    return;
}
while (!token.IsCancellationRequested)
{
    for (int level = 0; level < levels.Length; level++)
    {
        List<MessageDTO> messages = Extractor.ExtractMessages(level);
        Writer.writeMessages(messages);
    }
}



/*
const int counttt = 1554; // at most reads (counttt) messages from a stream

var readManual = Task.Run(async () =>
{
    List<RedisValue> msgsID = new List<RedisValue>();
    while (!token.IsCancellationRequested)
    {
        var messages = await db.StreamReadGroupAsync(streamName, groupName, myConsumerID, ">", counttt, true);
        //db.StreamDeleteAsync(streamName, msgsID);
        foreach (var entry in messages)
        {
            // Get the message ID
            var messageId = entry.Id;
            msgsID.Add(messageId);
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
        }
        StreamInfo res32 = db.StreamInfo(streamName);
        Console.WriteLine(res32.Length);
        //Console.WriteLine($"length: {res32.Length}, radix-tree-keys: {res32.RadixTreeKeys}, radix-tree-nodes: {res32.RadixTreeNodes}, last-generated-id: {res32.LastGeneratedId}, first-entry: {$"{res32.FirstEntry.Id}: [{string.Join(", ", res32.FirstEntry.Values.Select(b => $"{b.Name}: {b.Value}"))}]"}, last-entry: {$"{res32.LastEntry.Id}: [{string.Join(", ", res32.LastEntry.Values.Select(b => $"{b.Name}: {b.Value}"))}]"}");
        Console.WriteLine("*******************************************************\n\n\n\n\n\n");
        try
        {
            var x = res32.FirstEntry.Id;
            var y = res32.LastEntry.Id;
            await db.StreamDeleteAsync(streamName, msgsID.ToArray());

        }
        catch (Exception ex)
        {

        }
        finally
        {
            await Task.Delay(1000);
        }
    }

});


tokenSource.CancelAfter(TimeSpan.FromSeconds(300));

await Task.WhenAll(readManual);


/*StreamInfo res32 = db.StreamInfo(streamName);
Console.WriteLine($"length: {res32.Length}, radix-tree-keys: {res32.RadixTreeKeys}, radix-tree-nodes: {res32.RadixTreeNodes}, last-generated-id: {res32.LastGeneratedId}, first-entry: {$"{res32.FirstEntry.Id}: [{string.Join(", ", res32.FirstEntry.Values.Select(b => $"{b.Name}: {b.Value}"))}]"}, last-entry: {$"{res32.LastEntry.Id}: [{string.Join(", ", res32.LastEntry.Values.Select(b => $"{b.Name}: {b.Value}"))}]"}");
var x = res32.FirstEntry.Id;
var y = res32.LastEntry.Id;
RedisValue[] RedisValues = new RedisValue[2];
RedisValues[0] = x;
RedisValues[1] = y;
await db.StreamDeleteAsync(streamName , RedisValues);*/







