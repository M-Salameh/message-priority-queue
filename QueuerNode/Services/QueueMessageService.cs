
using Grpc.Core;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;
using SchedulerNode.RedisQueuer;

namespace SchedulerNode.Services
{
    public class QueueMessageService : Queue.QueueBase
    {
        private readonly ILogger<QueueMessageService> _logger;
        private readonly IDiscoveryClient _client;

        private readonly static string ErrorQueuing = "Error";
        public readonly static string ErrorConnection = "Error Connecting to Redis";
        public QueueMessageService(ILogger<QueueMessageService> logger , IDiscoveryClient client)
        {
            _logger = logger;
            _client = client;
            //MessageQueues.init();
        }

        public override Task<Acknowledgement> QueueMessage(Message message, ServerCallContext context)
        {

            //Console.WriteLine("Message Receieved to Queuer !!");

            string reqId = MessageQueues.addMessage(message, _client);

            Console.WriteLine("req id grcp que = " + reqId);

            if (reqId.Equals(MessageQueues.RedisConnectionError))
            {
                return Task.FromResult(new Acknowledgement
                {
                    ReplyCode = ErrorQueuing,
                    RequestID = reqId,
                });
            }

            return Task.FromResult(new Acknowledgement
            {
                ReplyCode = "OK on Send : id = " + message.MsgId + " ==> Message Reached Queue"
                + " with priority : " + message.LocalPriority ,
                
                RequestID = reqId
            });

        }
    }
}
