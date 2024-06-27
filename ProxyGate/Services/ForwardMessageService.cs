using Grpc.Core;
using Grpc.Net.Client;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace ProxyGateGRPC.Services
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
            //my port = 9090

            Console.WriteLine("Accepted" + message.ApiKey);

            using var channel = GrpcChannel.ForAddress("https://localhost:9091");

            var client = new Send.SendClient(channel);

            Message2 message2 = new Message2();
            message.ApiKey = message.ApiKey;
            message2.MsgId = message.MsgId; ;
            message2.LocalPriority = message.LocalPriority;
            message2.PhoneNumber = message2.PhoneNumber;
            message2.Text = message.Text;
            message2.ClientID = message.ClientID;

            Acknowledgement2 acknowledgement2 = client.SendMessage(message2);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("IN Queue ??");
            Console.ForegroundColor = ConsoleColor.Black;

            return Task.FromResult(new Acknowledgement
            { ReplyCode = acknowledgement2.ReplyCode});
            

        }

    }
}
