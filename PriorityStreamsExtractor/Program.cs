using PriorityStreamsExtractor;
using PriorityStreamsExtractor.Initializer;
using PriorityStreamsExtractor.StreamsHandler;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
Initializer.init(ref config);

string redis_read = ReadRedisInfoParser.connection;
string redis_wite = WriteRedisInfoParser.connection;

try
{
    TotalWorker.setAll();
}

catch (Exception ex)
{
    return;
}

await host.RunAsync();
