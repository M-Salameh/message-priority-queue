using CoordinatorOne;
using Steeltoe.Discovery.Client;

/*public class Program
{
    public static async void main(String[] args)
    {

        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHostedService<Worker>();
                services.AddDiscoveryClient();
            })
            .Build();

        await host.RunAsync();
    }
}
*/

IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHostedService<Worker>();
                services.AddDiscoveryClient();
                services.AddGrpc();
            })
            .Build();

// i need to MapGrpcService<QMSGSERvice>();


host.Run();