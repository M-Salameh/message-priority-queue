using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuerNode.Helper
{
    public class MessageQueues
    {
        private const int priority_levels = 6;

        private const int sms_rates = 15;

        private Queue<Message>[] messageQueue;

        private object[] locks;

        public MessageQueues()
        {
            messageQueue = new Queue<Message>[priority_levels];
            locks = new object [priority_levels];
            for (int i=0; i < priority_levels; i++)
            {
                messageQueue[i] = new Queue<Message>();
                locks[i] = new object();
            }
        }

        public void addMessage(Message message)
        {
            int idx = message.LocalPriority;
            idx = Math.Min(idx, priority_levels - 1);
            idx = Math.Max(idx, 0);
            Console.WriteLine("idx = " + idx);

            insert(message, idx);
            
            Console.WriteLine("Message Queued: " + message.MsgId);

        }

        private void insert(Message message , int index)
        {   
            lock (locks[index])
            {
                messageQueue[index].Enqueue(message);
                Console.WriteLine("INserted in Q : " + index);
            }
        }

        public void sendMessages()
        {
            int x1 = 7, x2 = 5, x3 = 3;
            while(x1>0 && messageQueue[1].Count>0)
            {
                Console.WriteLine(messageQueue[1].Dequeue());
                x1--;
            }

            while (x2 > 0 && messageQueue[1].Count > 0)
            {
                Console.WriteLine(messageQueue[2].Dequeue());
                x2--;
            }

            while (x3 > 0 && messageQueue[3].Count > 0)
            {
                Console.WriteLine(messageQueue[3].Dequeue());
                x3--;
            }
        }
    }
}
