using GGRPCMessageGenerator;
using Steeltoe.Discovery.Client;

IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHostedService<Worker>();
                services.AddDiscoveryClient();
            })
            .Build();

host.Run();