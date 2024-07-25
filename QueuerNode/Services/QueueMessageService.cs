
using Grpc.Core;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;
using SchedulerNode.RedisQueuer;
using Scheduler.MongoMessages;

namespace SchedulerNode.Services
{
    public class QueueMessageService : Queue.QueueBase
    {
        private readonly ILogger<QueueMessageService> _logger;
        private readonly IDiscoveryClient _client;
        
        private readonly static string ErrorQueuing = "Error";
        public readonly static string ErrorConnection = "Error Connecting to Redis";
        public readonly static string MyId = "Scheduler-1";
        public QueueMessageService(ILogger<QueueMessageService> logger , IDiscoveryClient client)
        {
            _logger = logger;
            _client = client;
        }

        public override Task<Acknowledgement> QueueMessage(Message message, ServerCallContext context)
        {

            //Console.WriteLine("Message Receieved to Queuer !!");
            if (message.Year == 0)
            {
                return Task.FromResult(SendAsap(ref message));
            }

            else
            {
                return Task.FromResult(Schedule(ref message));
            }

        }

        public Acknowledgement SendAsap(ref Message message)
        {
            string reqId = MessageQueues.addMessage(message);

            Console.WriteLine("req id grcp que = " + reqId);

            if (reqId.Equals(MessageQueues.RedisConnectionError))
            {
                return (new Acknowledgement
                {
                    ReplyCode = ErrorQueuing,
                    RequestID = reqId,
                });
            }

            return (new Acknowledgement
            {
                ReplyCode = "OK on Send : id = " + message.MsgId + " ==> Message Reached Queue"
                + " with priority : " + message.LocalPriority,

                RequestID = reqId
            });
        }
    
    
        private Acknowledgement Schedule(ref Message message)
        {
            string res = MongoMessagesShceduler.insertMessage(ref message);
            if (res.Equals (MongoMessagesShceduler.ConnectionError))
            {
                return new Acknowledgement
                {
                    ReplyCode = ErrorQueuing,
                    RequestID = res
                };
            }
            else
            {
                return new Acknowledgement
                {
                    ReplyCode = res,
                    RequestID = "id = some id"
                };
            }
        }
        
    }
}
