namespace Validator.Initializer
{
    public class AccountsDBParser
    {
        public static string connection = "";
        public static string DBName = "";
        public static string collection = "";
        public static void setAccountsDB(ref IConfiguration config)
        {
            string? conn = config.GetSection("AccountsDB").GetSection("Mongo").Value;
            string? dbname = config.GetSection("AccountsDB").GetSection("DBName").Value;
            string? collName = config.GetSection("AccountsDB").GetSection("collection").Value;

            if (conn == null || dbname == null || collName == null)
            {
                throw new ArgumentException("Accounts MongoDB DataBase Full Info (URL + DBName + collection) Not Defined in appsettings.json");
            }
            connection = conn;
            DBName = dbname;
            collection = collName;
        }
    }
}
