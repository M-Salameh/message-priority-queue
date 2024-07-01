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
        private readonly IDiscoveryClient discoveryClient;
        public QueueMessageController(ILogger<QueueMessageController> logger , IDiscoveryClient discovery)
        {
            _logger = logger;
            discoveryClient = discovery;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        [Route("/queue-msg")]
        [HttpPost]
        public string SendMessage([FromBody] MessageDTO messageDTO)
        {
            Console.WriteLine("Msg from : " + messageDTO.clientID);

            string validator = getValidatorAddress();

            Message message = copyMessage(messageDTO);

            bool res = PriorityHandling.SetPriority.setFinalPriority(ref message , validator);
            

            if (res == false)
            {
                return "Error";
            }
            
            string address = getAddress();
            using var channel = GrpcChannel.ForAddress(address);
            var client = new Queue.QueueClient(channel);


            Console.WriteLine("Sending to " + address);



            var reply = client.QueueMessage(message);

            Console.WriteLine(reply.ReplyCode);
            
            return (reply.ReplyCode );
            

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
        private string getAddress()
        {
            string address = "";

            var y = discoveryClient.GetInstances("QueuerNode"); /// write names to config file

            address = y[0].Uri.ToString();

            return address;
        }

        private string getValidatorAddress()
        {
            string address = "";

            var y = discoveryClient.GetInstances("Validator"); /// write names to config file

            address = y[0].Uri.ToString();

            return address;
        }
    }
}