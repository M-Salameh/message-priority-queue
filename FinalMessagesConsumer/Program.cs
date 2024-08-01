using FinalMessagesConsumer;
using FinalMessagesConsumer.StreamsHandler;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();
string redis_read = "localhost:6400";

try
{
    TotalWorker.setAll(redis_read);
}

catch (Exception ex)
{
    return;
}
await host.RunAsync();
