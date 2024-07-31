namespace Scheduler.Initializer
{
    public class MessagesMongoDBParser
    {
        public static string connection = "";
        public static string database = "";
        public static string collection = "";
        public static void setAccountsDB(ref IConfiguration config)
        {
            string? conn = config.GetSection("MessageStorage").GetSection("Mongo").Value;
            string? namedb = config.GetSection("MessageStorage").GetSection("DBName").Value;
            string? colldb = config.GetSection("MessageStorage").GetSection("collection").Value;
            if (conn == null || namedb == null || colldb == null)
            {
                throw new ArgumentException("Messages MongoDB DataBase Full Information (DBName + Collection + Not Defined in appsettings.json");
            }
            connection = conn;
            database = namedb;
            collection = colldb;
        }
    }
}
