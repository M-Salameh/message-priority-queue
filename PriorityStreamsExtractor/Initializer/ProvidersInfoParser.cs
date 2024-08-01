using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityStreamsExtractor.Initializer
{
    public class ProvidersInfoParser
    {
        public static string MTN = "";
        public static string Syriatel = "";
        public static void setInfo(ref IConfiguration config)
        {
            var syr_sect = config.GetSection("RedisInfo").GetSection("Providors").GetSection("Syriatel");
            var mtn_sect = config.GetSection("RedisInfo").GetSection("Providors").GetSection("MTN");

            string? stag = syr_sect.GetSection("Tag").Value;

            string? mtag = mtn_sect.GetSection("Tag").Value;

            if (stag == null || mtag == null)
            {
                throw new ArgumentException("Providers Full Info (Names(Tags) + Sms_Rate) Not Defined in appsettings.json");
            }

            MTN = mtag;
            Syriatel = stag;

        }
    }
}
