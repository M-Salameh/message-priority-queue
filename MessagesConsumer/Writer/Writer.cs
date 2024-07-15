using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesConsumer.Writer
{
    public class Writer
    {
        public static void writeMessage(MessageDTO message)
        {
            Console.WriteLine("Received : ");
            Console.WriteLine("Content " + message.text);
            Console.WriteLine("Phone Number = " + message.phoneNumber);
        }

    }
}
