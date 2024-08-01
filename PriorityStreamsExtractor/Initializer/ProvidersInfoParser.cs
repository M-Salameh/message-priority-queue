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
        public static int mtn_rate = 0;
        public static int syr_rate = 0;
        public static void setInfo(ref IConfiguration config)
        {
            var syr_sect = config.GetSection("RedisInfo").GetSection("Providors").GetSection("Syriatel");
            var mtn_sect = config.GetSection("RedisInfo").GetSection("Providors").GetSection("MTN");

            string? stag = syr_sect.GetSection("Tag").Value;
            string? srate = syr_sect.GetSection("sms_rate").Value;

            string? mtag = mtn_sect.GetSection("Tag").Value;
            string? mrate = mtn_sect.GetSection("sms_rate").Value;

            if (stag == null || srate == null || mtag == null || mrate == null)
            {
                throw new ArgumentException("Providers Full Info (Names(Tags) + Sms_Rate) Not Defined in appsettings.json");
            }

            MTN = mtag;
            Syriatel = stag;
            mtn_rate = int.Parse(mrate);
            syr_rate = int.Parse(srate);
        }
    }
}
