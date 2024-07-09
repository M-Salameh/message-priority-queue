using CSRedis;
using SimpleStreamConsumerTest;
using StackExchange.Redis;
using Newtonsoft.Json;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

string SYR = "localhost:6374";

var muxer = ConnectionMultiplexer.Connect(SYR);
var db = muxer.GetDatabase();

const string streamName3 = "3";
const string groupName = "SYS_MSGS";
const string myConsumerID = "some-id";

const int count = 1554; // at most reads (count) messages from a stream

var readManual = Task.Run(async () =>
{
    /*TimeSpan blockTime = TimeSpan.FromSeconds(0.2);
    string rest = "GROUP " + groupName + " id "
     + "BLOCK " + blockTime.TotalMilliseconds + " "
     + "COUNT " + count 
     + " STREAMS " + streamName3 + " >";
    
    string[] rest2 = { "GROUP "
                        , groupName
                        , myConsumerID
                        , "COUNT " 
                        , count.ToString()
                        , "BLOCK " 
                        , blockTime.TotalMilliseconds.ToString()
                        , "STREAMS " 
                        , streamName3
                        ,">"};
    
    string[] rest3 = {groupName
                        , myConsumerID
                        , count.ToString()
                        , blockTime.TotalMilliseconds.ToString()
                        , streamName3
                        ,">"};*/

    string cmd = "XREADGROUP";


    /*
      items = r.xreadgroup("GROUP",GroupName,ConsumerName,"BLOCK","2000","COUNT","10","STREAMS",:my_stream_key,myid)
     */
    // var res = db.Execute(cmd , rest3);
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










