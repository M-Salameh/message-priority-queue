using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMessagesConsumer.Initializer
{
    public class ReadRedisInfoParser
    {
        public static string connection = "";
        public static string consumer_id = "";
        public static void setInfo(ref IConfiguration config)
        {
            var sect = config.GetSection("RedisInfo").GetSection("Read");

            string? conn = sect.GetSection("Connection").Value;
            string? id = sect.GetSection("ConsumerID").Value;
            
            if (conn == null || id == null)
            {
                throw new ArgumentException("Read Redis Full Info (connection + consumer id) Not Defined in appsettings.json");
            }

            connection = conn;
            consumer_id = id;

        }
    }
}
