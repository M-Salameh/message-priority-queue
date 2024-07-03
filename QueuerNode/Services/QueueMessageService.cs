
using Grpc.Core;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;
using QueuerNode.RedisQueuer;

namespace QueuerNode.Services
{
    public class QueueMessageService : Queue.QueueBase
    {
        private readonly ILogger<QueueMessageService> _logger;
        private readonly IDiscoveryClient _client;
        public QueueMessageService(ILogger<QueueMessageService> logger , IDiscoveryClient client)
        {
            _logger = logger;
            _client = client;
        }

        public override Task<Acknowledgement> QueueMessage(Message message, ServerCallContext context)
        {

            //Console.WriteLine("Message Receieved to Queuer !!");

            string reqId = MessageQueues.addMessage(message, _client);

            return Task.FromResult(new Acknowledgement
            {
                ReplyCode = "OK on Send : id = " + message.MsgId + " ==> Message Reached Queue"
                + " with priority : " + message.LocalPriority
                
                ,
                
                RequestID = reqId
            });

        }
    }
}
