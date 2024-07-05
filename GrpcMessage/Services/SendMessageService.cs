
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
        private static readonly string ErrorValidation = "Error When Validating Request";
        private static readonly string ErrorDBConnection = "Error Connecting to DataBase";
        private static readonly string ErrorConnection = "Error Connecting to Servers";
        private static readonly string ErrorGRPCConnection = "Error Connecting to GRPC Servers";
        private static readonly string QueuerNode = "QueuerNode";
        private static readonly string Validator = "Validator";


        public SendMessageService(ILogger<SendMessageService> logger , IDiscoveryClient client)
        {
            _logger = logger;
            discoveryClient = client;
        }

        public override Task<Acknowledgement> SendMessage(Message message, ServerCallContext context)
        {
            string validator = getAddressOfInstance(Validator);
            if (validator == ErrorConnection)
            {
                return Task.FromResult(new Acknowledgement
                {
                    ReplyCode = ErrorConnection,
                    RequestID = ErrorDBConnection
                }) ;
            }
            Console.WriteLine("Pr = " + message.LocalPriority);

            
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

            Console.WriteLine("new Pr = " + message.LocalPriority);


            //Console.WriteLine("Account Checker Passed ");
            Acknowledgement reply = sendToCoordinator(message);

            return Task.FromResult(new Acknowledgement(reply));
        }

        private Acknowledgement sendToCoordinator(Message message)
        {
            string address = getAddressOfInstance(QueuerNode);
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

        //not working -- causing unknown exception with nullable parameter http2
        private Queue.QueueClient getQueueClient()
        {
            string address = getAddressOfInstance(QueuerNode);
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
            message2.Tag = message.Tag; 
            return message2;
        }


        private string getAddressOfInstance(string instanceName)
        {
            string address = "";
            try
            {
                // instanceName = "Validator" or "QueuerNode" ... etc
                var y = discoveryClient.GetInstances(instanceName); /// write names to config file

                address = y[0].Uri.ToString();

                return address;
            }
            catch (Exception ex)
            {
                return ErrorConnection;
            }
        }
    }
}
