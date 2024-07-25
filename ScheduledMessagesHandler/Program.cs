
using ScheduledMessagesHandler;
using ScheduledMessagesHandler.MongoMessages;
using ScheduledMessagesHandler.RedisQueuer;
using Steeltoe.Discovery.Client;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddDiscoveryClient();
    })
    .Build();


MessageQueues.init();

MongoMessagesShceduler.init();

await host.RunAsync();
