using CSRedis;
using StackExchange.Redis;
using Newtonsoft.Json;
using MessagesConsumer.StreamsHandler;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

string redis_read = "localhost:6379";

try
{
    TotalWorker.setAll(redis_read);
}

catch (Exception ex)
{
    return;
}

string[] provs = new string[] { "MTN", "SYR" };
int turn = 0;

while (!token.IsCancellationRequested)
{

    TotalWorker.work(provs[turn]);

    turn ^= 1;

    Console.WriteLine("\n\n\n\n");
    
    TotalWorker.work(provs[turn]);
    
    turn ^= 1;

    Console.WriteLine("**************************************************");

    await Task.Delay(1000);
}





