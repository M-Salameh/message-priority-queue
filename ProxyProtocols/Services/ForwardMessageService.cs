using Grpc.Core;
using Grpc.Net.Client;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;


namespace ProxyProtocolsGRPC.Services
{
    public class ForwardMessageService : Forward.ForwardBase
    {
        private readonly ILogger<ForwardMessageService> _logger;
        private readonly DiscoveryHttpClientHandler _handler;
        public ForwardMessageService(ILogger<ForwardMessageService> logger, IDiscoveryClient client)
        {
            _logger = logger;
            _handler = new DiscoveryHttpClientHandler(client);
        }

        
        public override Task<Acknowledgement> ForwardMessage (Message message, ServerCallContext context)
        {
            // my port = 9099
            using var channel = GrpcChannel.ForAddress("https://localhost:9091");

            var client = new Send.SendClient(channel);

            Acknowledgement acknowledgement = client.SendMessage(message);

            Console.WriteLine("In Queue ?");

            return Task.FromResult(acknowledgement);
            

        }

    }
}
