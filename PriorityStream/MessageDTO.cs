using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityStream
{
    public class MessageDTO
    {
        public string? clientID { get; set; }
        public string? apiKey { get; set; }
        public string? msgId { get; set; }
        public string? phoneNumber { get; set; }
        public int localPriority { get; set; }
        public string? text { get; set; }
        public string? tag { get; set; }
    }
}
