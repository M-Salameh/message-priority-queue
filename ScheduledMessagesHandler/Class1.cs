using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduledMessagesHandler
{
    public static class RedisInitializeExtentions
    {
        //Extention methods
        public static IHost InitRedis(this IHost host) 
        {


            return host;
        }


    }
}
