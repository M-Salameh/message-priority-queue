using PriorityStreamsExtractor.StreamsHandler;

namespace PriorityStreamsExtractor
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
            string[] provs = new string[] { "MTN", "SYR" };
            int turn = 0;
            int[] levels = new int[] { 1, 2, 3, 4, 5 };

            while (true)
            {

                for (int i = 0; i < levels.Length; i++)
                {
                    TotalWorker.work(provs[turn] + "_" + levels[i]);
                }

                turn ^= 1;

                //Console.WriteLine("**************************************************");

                await Task.Delay(1000);
            }
        }
    }
}