using FinalMessagesConsumer;
using FinalMessagesConsumer.Initializer;
using FinalMessagesConsumer.StreamsHandler;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
Initializer.init(ref config);

try
{
    TotalWorker.setAll();
}

catch (Exception ex)
{
    return;
}
await host.RunAsync();
