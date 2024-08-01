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
string redis_read = "localhost:6379";
string redis_wite = "localhost:6400";

try
{
    TotalWorker.setAll(redis_read, redis_wite);
}

catch (Exception ex)
{
    return;
}

await host.RunAsync();
