using GGRPCMessageGenerator;
using Steeltoe.Discovery.Client;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                    services.AddDiscoveryClient();
                })
                .Build();

        host.Run();
    }
}
