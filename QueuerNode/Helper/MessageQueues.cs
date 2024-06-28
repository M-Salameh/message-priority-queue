using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuerNode.Helper
{
    public static class MessageQueues
    {
        private const int priority_levels = 6;

        private const int sms_rates = 15;

        private static Queue<Message>[] messageQueue = new Queue<Message>[priority_levels];

        public static void addMessage(Message message)
        {
            int idx = message.LocalPriority;
            idx = Math.Min(idx, priority_levels - 1);
            idx = Math.Max(idx, 0);
            Console.WriteLine("idx = " + idx);

            messageQueue[idx].Enqueue(message);
            Console.WriteLine("Message Queued: " + message.MsgId);

        }

        public static void sendMessages()
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
