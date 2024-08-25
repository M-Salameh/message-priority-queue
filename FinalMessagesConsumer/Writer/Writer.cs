using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMessagesConsumer.Writer
{
    public class Writer
    {
        private static readonly object locks = new object();
        public static void writeMessage(MessageDTO message)
        {
                lock (locks)
                {
                    WriteToFile(ref message);
                } 
        }
        private static void WriteToFile(ref MessageDTO message)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            // Create a file path within the current directory
            string filePath = Path.Combine(currentDirectory, message.tag + "output.txt");



            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("api-key : " + message.apiKey);
                writer.WriteLine("ClientID : " + message.clientID);
                writer.WriteLine("Priority : " + message.localPriority);
                writer.WriteLine("GateWay : " + message.tag);
                try
                {
                    DateTime des = new DateTime(message.year, message.month, message.day, message.hour, message.minute, 0);
                    writer.WriteLine("Scheduling Date : " + "des");
                }
                catch (Exception ex)
                {
                    writer.WriteLine("Scheduling Date : " + "ASAP");

                }
                writer.WriteLine("Content : " + message.text);
                writer.WriteLine("******************************************");
            }
        }

    }
}
