using Steeltoe.Discovery;

namespace CoordinatorOne
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IDiscoveryClient discoveryClient;
        public Worker(ILogger<Worker> logger , IDiscoveryClient client)
        {
            _logger = logger;
            discoveryClient = client;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            /*wile (!stoppingToken.IsCancellationRequested)
            {
               var x = discoveryClient.Services;
                Console.WriteLine(x);
                var y = discoveryClient.GetInstances("grpcmessagenode");
                var yy = discoveryClient.GetInstances("grpcmessagenod444e");

                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }*/
        }
    }
}