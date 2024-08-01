namespace ScheduledMessagesHandler.Initializer
{
    public class RedisInfoParser
    {
        public static string connection = "";
        public static string MTN = "";
        public static string Syriatel = "";

        public static void setInfo(ref IConfiguration config)
        {
            string? conn = config.GetSection("RedisInfo").GetSection("WriteConnection").Value;
            string? syr = config.GetSection("RedisInfo").GetSection("Providors").GetSection("Syriatel").Value;
            string? mtn = config.GetSection("RedisInfo").GetSection("Providors").GetSection("MTN").Value;
            if (conn == null || syr == null || mtn == null)
            {
                throw new ArgumentException("Redis Full Info (connection + providers) Not Defined in appsettings.json");
            }

            connection = conn;
            Syriatel = syr;
            MTN = mtn;
        }
    }
}
