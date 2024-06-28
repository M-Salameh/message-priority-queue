
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

            bool res = PriorityHandling.SetPriority.setFinalPriority(message);

            if (res == false) // something went wrong
            {
                return Task.FromResult(new Acknowledgement
                {
                    ReplyCode = "ERRORROROR on Send " + message.MsgId
                });
            }

            //Console.WriteLine("Account Checker Passed ");
            string reply = sendToCoordinator(message);

            return Task.FromResult(new Acknowledgement
            {
                ReplyCode = reply //"OK on Send " + message.MsgId
            });
        }

        private string sendToCoordinator(Message message)
        {
            string address = getCoordinatorAddress();
            Message2 message2 = copyMessage(message);

            using var channel = GrpcChannel.ForAddress(address);

            var queue_client = new Queue.QueueClient(channel);

            var reply = queue_client.QueueMessage(message2);

           // Console.WriteLine(reply.ReplyCode);

            return reply.ReplyCode;
        }

        //not working -- causing unknown exception with nullable parameter http2
        private Queue.QueueClient getQueueClient()
        {
            string address = getCoordinatorAddress();
            using var channel = GrpcChannel.ForAddress(address);
            //Console.WriteLine("QueuerNode Address  = " + address);
            var client = new Queue.QueueClient(channel);
            return client;
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

        private string getCoordinatorAddress()
        {
            string address = "";

            var y = discoveryClient.GetInstances("QueuerNode"); /// write names to config file

            address = y[0].Uri.ToString();

            return address;
        }
    }
}
