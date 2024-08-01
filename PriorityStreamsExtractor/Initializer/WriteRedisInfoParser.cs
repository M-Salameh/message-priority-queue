using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityStreamsExtractor.Initializer
{
    public class WriteRedisInfoParser
    {
        public static string connection = "";
        public static void setInfo(ref IConfiguration config)
        {
            var sect = config.GetSection("RedisInfo").GetSection("Write");

            string? conn = sect.GetSection("Connection").Value;

            if (conn == null)
            {
                throw new ArgumentException("Write Redis Info (connection) Not Defined in appsettings.json");
            }

            connection = conn;

        }
    }
}
