using CSRedis;
using StackExchange.Redis;
using Newtonsoft.Json;
using PriorityStream;
using PriorityStream.StreamsHandler;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

string redis_read = "localhost:6379";
string redis_wite = "localhost:6400";

try
{
    TotalWorker.setAll(redis_read , redis_wite);
}

catch (Exception ex)
{
    return;
}

string[] provs = new string[] { "MTN", "SYR" };
int turn = 0;
int[] levels = new int[] { 1, 2, 3, 4, 5 };

while (!token.IsCancellationRequested)
{

    for (int i = 0; i < levels.Length ; i++)
    {
        TotalWorker.work(provs[turn]+"_"+levels[i]);
    }

    turn ^= 1;

    Console.WriteLine("**************************************************");

    await Task.Delay(1000);
}





