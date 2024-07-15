using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Steeltoe.Discovery;

namespace HTTPMessageNode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueueMessageController : ControllerBase
    {

        private readonly ILogger<QueueMessageController> _logger;
        private IDiscoveryClient discoveryClient;
        public static readonly string ErrorConnection = "Error Connecting to Servers";
        private static readonly string Scheduler = "SchedulerNode"; //put them in files!
        private static readonly string Validator = "Validator";
        private static readonly string ErrorDBConnection = "Error Connecting to DataBase";
        private static readonly string ErrorValidation = "Error When Validating Request";
        private static readonly string ErrorGRPCConnection = "Error Connecting to GRPC Servers";

        public QueueMessageController(ILogger<QueueMessageController> logger , IDiscoveryClient discovery, IConfiguration configuration)
        {
            _logger = logger;
            discoveryClient = discovery;
            //Console.WriteLine("Conf = " + configuration.GetValue<string>("database:conn"));
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        [Route("/queue-msg")]
        [HttpPost]
        public Acknowledgement SendMessage([FromBody] MessageDTO messageDTO)
        {
            //Console.WriteLine("Msg from : " + messageDTO.clientID + " pr  = " + messageDTO.localPriority);

            string validator = LoadBalancer.AddressResolver.getAddressOfInstance(Validator, ref discoveryClient);
            if (validator == ErrorConnection)
            {
                return (new Acknowledgement
                {
                    ReplyCode = ErrorConnection,
                    RequestID = ErrorDBConnection
                });
            }

            Message message = copyMessage(messageDTO);

            Console.WriteLine("old prio = " + message.LocalPriority);

            string res = PriorityHandling.SetPriority.setFinalPriority(ref message , validator);


            if (!res.Equals(DataBaseAccess.DBAccess.OK)) // something went wrong
            {
                return (new Acknowledgement
                {
                    ReplyCode = res,
                    RequestID = ErrorValidation + " : " + res
                });
            }

            Console.WriteLine("new prio = " + message.LocalPriority);


            string address = LoadBalancer.AddressResolver.getAddressOfInstance(Scheduler, ref discoveryClient);
            if (address == ErrorConnection)
            {
                return (new Acknowledgement
                {
                    ReplyCode = ErrorConnection,
                    RequestID = ErrorConnection
                });
            }
            using var channel = GrpcChannel.ForAddress(address);
            var client = new Queue.QueueClient(channel);

            //Console.WriteLine("Sending to " + address);

            //Console.WriteLine(message.Tag + " , " + message.ClientID + " new pr = " + message.LocalPriority); ;


            try
            {
                var reply = client.QueueMessage(message);

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

        private Message copyMessage(MessageDTO messageDTO)
        {
            Message message = new Message();
            message.MsgId = messageDTO.msgId;
            message.Text = messageDTO.text;
            message.LocalPriority =  messageDTO.localPriority;
            message.PhoneNumber = messageDTO.phoneNumber;
            message.ApiKey = messageDTO.apiKey;
            message.ClientID = messageDTO.clientID;
            message.Tag = messageDTO.tag;
            return message;
        }


        /*private string getAddressOfInstance(string instanceName)
        {
            string address = "";
            try
            {
                // instanceName = "Validator" or "Scheduler" ... etc
                var y = discoveryClient.GetInstances(instanceName); /// write names to config file

                address = y[0].Uri.ToString();

                return address;
            }
            catch (Exception ex)
            {
                return ErrorConnection;
            }
        }*/
    }
}