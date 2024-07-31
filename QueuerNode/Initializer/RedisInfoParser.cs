namespace Scheduler.Initializer
{
    public class RedisInfoParser
    {
        public static string connection = "";
        public static string MTN = "";
        public static string Syriatel = "";
        public static int LEVELS = 0;
        public static void setInfo(ref IConfiguration config)
        {
            string? conn = config.GetSection("RedisInfo").GetSection("Connection").Value;
            string? provs = config.GetSection("RedisInfo").GetSection("Providors").Value;
            string? lvls = config.GetSection("RedisInfo").GetSection("Levels").Value;
            if (conn == null || provs == null || lvls == null )
            {
                throw new ArgumentException("Redis Full Info (connection + providers + levels) Not Defined in appsettings.json");
            }
            connection = conn;
            LEVELS = int.Parse(lvls);
            string[] temp = provs.Split(',');
            Syriatel = temp[0];
            MTN = temp[1];
        }
    }
}
