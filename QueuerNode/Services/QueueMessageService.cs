
using Grpc.Core;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;
using QueuerNode.Helper;

namespace QueuerNode.Services
{
    public class QueueMessageService : Queue.QueueBase
    {
        private readonly ILogger<QueueMessageService> _logger;
        private readonly IDiscoveryClient _client;
        private MessageQueues _messageQueues;
        public QueueMessageService(ILogger<QueueMessageService> logger , IDiscoveryClient client)
        {
            _logger = logger;
            _client = client;
            _messageQueues = new MessageQueues();
        }

        public override Task<Acknowledgement> QueueMessage(Message message, ServerCallContext context)
        {

            //Console.WriteLine("Message Receieved to Queuer !!");

            _messageQueues.addMessage(message);
            
            return Task.FromResult(new Acknowledgement
            {
                ReplyCode = "OK on Send : id = " + message.MsgId + " ==> Message Reached Queue"
            });
        }
    }
}
