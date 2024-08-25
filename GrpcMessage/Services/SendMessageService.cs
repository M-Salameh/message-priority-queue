
using Grpc.Core;
using Grpc.Net.Client;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace GrpcMessageNode.Services
{
    public class SendMessageService : Send.SendBase
    {
        private readonly ILogger<SendMessageService> _logger;
        private IDiscoveryClient discoveryClient;
        private static readonly string ErrorValidation = "Error When Validating Request";
        private static readonly string ErrorDBConnection = "Error Connecting to DataBase";
        public static readonly string ErrorConnection = "Error Connecting to Servers";
        private static readonly string ErrorGRPCConnection = "Error Connecting to GRPC Servers";
        private static readonly string Scheduler = "SchedulerNode";
        private static readonly string Validator = "Validator";


        public SendMessageService(ILogger<SendMessageService> logger , IDiscoveryClient client)
        {
            _logger = logger;
            discoveryClient = client;
        }

        public override Task<Acknowledgement> SendMessage(Message message, ServerCallContext context)
        {
            string validator = LoadBalancer.AddressResolver.getAddressOfInstance(Validator , ref discoveryClient);
            if (validator == ErrorConnection)
            {
                return Task.FromResult(new Acknowledgement
                {
                    ReplyCode = ErrorConnection,
                    RequestID = ErrorDBConnection
                }) ;
            }
            //Console.WriteLine("Pr = " + message.LocalPriority);

            
            string res = PriorityHandling.SetPriority.setFinalPriority(ref message , validator);
            
            if (!res.Equals(DataBaseAccess.DBAccess.OK)) // something went wrong
            {
                Console.WriteLine("Error when set Final setFinalPriority is called");
                return Task.FromResult(new Acknowledgement
                {
                    ReplyCode = res,
                    RequestID = ErrorValidation + " : " + res
                });
            }

            //Console.WriteLine("new Pr = " + message.LocalPriority);


            //Console.WriteLine("Account Checker Passed ");
            Acknowledgement reply = sendToCoordinator(message);

            return Task.FromResult(new Acknowledgement(reply));
        }

        /// <summary>
        /// Selects a Coordinator (Scheduler Node) with client side 
        /// load-balancing and send the message to it
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Acknowledgment of the Message containing the status (Success + Failure)</returns>
        private Acknowledgement sendToCoordinator(Message message)
        {
            string address = LoadBalancer.AddressResolver.getAddressOfInstance(Scheduler , ref discoveryClient);
            if (address == ErrorConnection)
            {
                return (new Acknowledgement
                {
                    ReplyCode = ErrorConnection,
                    RequestID = ErrorConnection
                });
            }
            Message2 message2 = copyMessage(message);

            using var channel = GrpcChannel.ForAddress(address);

            var queue_client = new Queue.QueueClient(channel);
            try
            {
                var reply = queue_client.QueueMessage(message2);

                // Console.WriteLine(reply.ReplyCode);

                return new Acknowledgement() { ReplyCode = reply.ReplyCode, RequestID = reply.RequestID };
            }
            catch (Exception e)
            {
                return new Acknowledgement()
                {
                    ReplyCode = ErrorConnection,
                    RequestID = ErrorGRPCConnection
                };
            }
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
            message2.Tag = message.Tag; 
            return message2;
        }
    }
}
