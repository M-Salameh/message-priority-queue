using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityStreamsExtractor.Initializer
{
    public class ReadRedisInfoParser
    {
        public static string connection = "";
        public static string group_name = "";
        public static string consumer_id = "";
        public static void setInfo(ref IConfiguration config)
        {
            var sect = config.GetSection("RedisInfo").GetSection("Read");

            string? conn = sect.GetSection("Connection").Value;
            string? cgroup = sect.GetSection("ConsumerGroup").Value;
            string? id = sect.GetSection("ConsumerID").Value;
            
            if (conn == null || cgroup == null || id == null)
            {
                throw new ArgumentException("Read Redis Full Info (connection + consumer group + consumer id) Not Defined in appsettings.json");
            }

            connection = conn;
            group_name = cgroup;
            consumer_id = id;

        }
    }
}
