using CSRedis;
using SimpleStreamConsumerTest;
using StackExchange.Redis;
using Newtonsoft.Json;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

string SYR = "localhost:6374";

var muxer = ConnectionMultiplexer.Connect(SYR);
var db = muxer.GetDatabase();

const int sms_rate = 10;
const string streamName = "SYR";
const string groupName = "SYS";
const string myConsumerID = "some-id";

const int count = sms_rate; // at most reads (count) messages from a stream
/*
var readManual = Task.Run(async () =>
{
    while (!token.IsCancellationRequested)
    {
        var res = await db.ExecuteAsync(cmd, "GROUP", groupName, myConsumerID, "BLOCK", 2000, "COUNT", 10, "STREAMS", streamName3, ">");

        Console.WriteLine("length = " + res.Length);

        if (res.Length <= 0) continue;
        /*var temp = res[0].ToDictionary();

        foreach (var r in temp)
        {
            Console.WriteLine(r.GetType());
            Console.WriteLine(r.Value);
        }*/
        
        ///
        /// mesg -> Value -> [0] -> [1] -> [1]
        ///
        /*
        var messages = res[0].ToDictionary();

        
        foreach (var message in messages)
        {
            Console.WriteLine(message.Key);
            Console.WriteLine(message.Value.GetType());
            //Console.WriteLine(message.Value[0][1][1]);
            MessageDTO? messaged = JsonConvert.DeserializeObject<MessageDTO>(message.Value[0][1][1]);
            //Console.WriteLine(messaged);

        }

        Console.WriteLine("*******************************************************");

        await Task.Delay(1000);
    }

});


tokenSource.CancelAfter(TimeSpan.FromSeconds(300));

await Task.WhenAll(readManual);

*/








