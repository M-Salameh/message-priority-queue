
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
            DateTime current = DateTime.Now;

            //Console.WriteLine("Message Receieved to Queuer !!");
            if (message.Year == 0 || message.Day == 0 || message.Month == 0)
            {
                return Task.FromResult(SendAsap(ref message));
            }
            
            DateTime des = new DateTime(message.Year, message.Month, message.Day, message.Hour, message.Minute, 0);
            
            if (DateTime.Compare(des,current)<=0)
            {
                return Task.FromResult(SendAsap(ref message));
            }

            else
            {
                return Task.FromResult(Schedule(ref message));
            }

        }

        /// <summary>
        /// Send Message to Redis Stream ASAP
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Acknowledgment: status of request and id if all goes well</returns>
        private Acknowledgement SendAsap(ref Message message)
        {
            MessageQueues Mq = new MessageQueues();
            string reqId = Mq.addMessage(message);

            //Console.WriteLine("req id ASAP que = " + reqId);

            if (reqId.Equals(Mq.RedisConnectionError))
            {
                return (new Acknowledgement
                {
                    ReplyCode = ErrorQueuing,
                    RequestID = reqId,
                });
            }

            return (new Acknowledgement
            {
                ReplyCode = "OK ",
                RequestID = Guid.NewGuid().ToString() + ":" + MyId
        });
        }


        /// <summary>
        /// Schedule Message and Write it to MongoDB to Send it When Dued
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Acknowledgment: status of request and id if all goes well</returns>
        private Acknowledgement Schedule(ref Message message)
        {
            MongoMessagesShceduler mongoMessagesShceduler = new MongoMessagesShceduler();
            string res = mongoMessagesShceduler.insertMessage(ref message);
            //Console.WriteLine("req id SCHEDULED que = " + res);
            if (res.Equals (mongoMessagesShceduler.ConnectionError))
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
                    RequestID = Guid.NewGuid().ToString() + ":" + MyId
                };
            }
        }
        
    }
}
