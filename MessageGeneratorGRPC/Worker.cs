using Grpc.Net.Client;
using Steeltoe.Discovery;

namespace GGRPCMessageGenerator
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDiscoveryClient discoveryClient;
        private readonly string ServersNotAvail = "Error, Servers not Available";
        public Worker(ILogger<Worker> logger, IDiscoveryClient client)
        {
            _logger = logger;
            discoveryClient = client;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string address = getAddress();
            Console.WriteLine(address);
            if(address == ServersNotAvail)
            {
                return;
            }
          //  address = "http://localhost:9091";

            /**using var channel = GrpcChannel.ForAddress(address , new GrpcChannelOptions
            {
                Credentials = Grpc.Core.ChannelCredentials.Insecure
            });*/
            using var channel = GrpcChannel.ForAddress(address);
            try
            {

                var client = new Send.SendClient(channel);

                Message message = new Message();
                message.Text = "Hello World !";
                message.ApiKey = "Api-Key";
                message.ClientID = "m-salameh";
                message.LocalPriority = 1;
                message.MsgId = "msg-id=1";
                message.PhoneNumber = "043 33 00 83";
                message.Tag = "SYR";
                message.Minute = message.Hour = message.Day = message.Month = message.Year = 0;

                Console.WriteLine("Sending to " + address);


                var reply = client.SendMessage(message);
                Console.WriteLine("Reply Arrived : ");
                Console.WriteLine(reply.ReplyCode + "\n" + reply.RequestID);
                //Console.WriteLine("OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
                //return Task.something;
            }

        }

        private string getAddress()
        {
            string address = "";
            try
            {
                var y = discoveryClient.GetInstances("grpc-message-node"); /// write names to config file

                address = y[0].Uri.ToString();
            }
            catch (Exception ex)
            {
                address = ServersNotAvail;
            }
            return address;
        }

    }
}