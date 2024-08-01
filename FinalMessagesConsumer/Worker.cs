using FinalMessagesConsumer.Initializer;
using FinalMessagesConsumer.StreamsHandler;

namespace FinalMessagesConsumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string[] provs = new string[] { ProvidersInfoParser.Syriatel, ProvidersInfoParser.MTN };
            int turn = 0;
            while (true)
            {
                
                TotalWorker.work(provs[turn]); 
                turn ^= 1;
                //Console.WriteLine("**************************************************");

                await Task.Delay(100000);
            }
        }
    }
}