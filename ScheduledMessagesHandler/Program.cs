
using ScheduledMessagesHandler;
using ScheduledMessagesHandler.Initializer;
using ScheduledMessagesHandler.MongoMessages;
using ScheduledMessagesHandler.RedisQueuer;
using Steeltoe.Discovery.Client;


IConfiguration config; 
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddDiscoveryClient();
    })
    .Build();

config = host.Services.GetRequiredService<IConfiguration>();

Initializer.init(ref config);


RedisSettingsInitializer.init();

MongoSettingsInitializer.init();

await host.RunAsync();
