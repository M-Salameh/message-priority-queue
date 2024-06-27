
using Grpc.Core;
using Grpc.Net.Client;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace GrpcMessageNode.Services
{
    public class SendMessageService : Send.SendBase
    {
        private readonly ILogger<SendMessageService> _logger;
        private readonly IDiscoveryClient discoveryClient;
        public SendMessageService(ILogger<SendMessageService> logger , IDiscoveryClient client)
        {
            _logger = logger;
            discoveryClient = client;
        }

        public override Task<Acknowledgement> SendMessage(Message message, ServerCallContext context)
        {
            Console.WriteLine("Got to Receiver Node");
            int priority = getPriority(message.ClientID);

            modifyPriority(message, priority);

            sendToCoordinator(message);

            return Task.FromResult(new Acknowledgement
            {
                ReplyCode = "OK on Send " + message.MsgId
            });
        }

        private void modifyPriority (Message message , int priority)
        {
            // apply some algorithm here
            message.LocalPriority += priority;
        }
        private int getPriority(string clientID)
        {
            // look up in data base
            int x = 5;
            return x;
        }
        private string sendToCoordinator(Message message)
        {
            string res = "k + ";

           
            string address = getAddress();
            using var channel = GrpcChannel.ForAddress(address);
            var client = new Queue.QueueClient(channel);

            Message2 message2 = copyMessage(message);

            var reply = client.QueueMessage(message2);

            Console.WriteLine(reply.ReplyCode);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            return res + reply.ReplyCode;
        }

        private Message2 copyMessage(Message message)
        {
            Message2 message2 = new Message2();
            message2.MsgId = message.MsgId;
            message2.Text = message.Text;
            message2.LocalPriority = message.LocalPriority;
            message2.ClientID = message.ClientID;
            message2.ApiKey = message.ApiKey;
            message2.PhoneNumber = message.PhoneNumber;
            return message2;
        }

        private string getAddress()
        {
            string address = "";

            var y = discoveryClient.GetInstances("Coordinator"); /// write names to config file

            address = y[0].Uri.ToString();

            return address;
        }
    }
}
