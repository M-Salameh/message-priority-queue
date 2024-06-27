using Grpc.Net.Client;
using Steeltoe.Discovery;

namespace MessageGeneratorGRPC
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDiscoveryClient discoveryClient;
        public Worker(ILogger<Worker> logger, IDiscoveryClient client)
        {
            _logger = logger;
            discoveryClient = client;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string address = getAddress();
            using var channel = GrpcChannel.ForAddress(address);
            var client = new Send.SendClient(channel);

            Message message = new Message();
            message.Text = "Hello World !";
            message.ApiKey = "Api-Key";
            message.ClientID = "m-salameh";
            message.LocalPriority = 1;
            message.MsgId = "msg-id=1";
            message.PhoneNumber = "043 33 00 83";

            var reply = client.SendMessage(message);

            Console.WriteLine(reply.ReplyCode);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }

        private string getAddress()
        {
            string address = "";

            var y = discoveryClient.GetInstances("grpc-message-node"); /// write names to config file
         
            address = y[0].Uri.ToString();
            
            return address;
        }
    }
}