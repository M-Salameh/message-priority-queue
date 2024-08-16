using Steeltoe.Discovery;
using MongoDB.Bson;
using MongoDB.Driver;
using ScheduledMessagesHandler.MongoMessages;

namespace ScheduledMessagesHandler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDiscoveryClient client;
        
        //public string ConnectionError = "Error Connecting to MongoDB on : " + MONGODB;
        public Worker(ILogger<Worker> logger , IDiscoveryClient discoveryClient)
        {
            _logger = logger;

            client = discoveryClient;        
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            MongoMessages.ScheduledMessagesHandler mongoMessagesHandler = new MongoMessages.ScheduledMessagesHandler();
            mongoMessagesHandler.getDuedMessagesAndQueue();
        }
    }
}