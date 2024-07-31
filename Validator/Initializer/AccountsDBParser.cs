namespace Validator.Initializer
{
    public class AccountsDBParser
    {
        public static string connection = "";
        public static void setAccountsDB(ref IConfiguration config)
        {
            string? conn = config.GetSection("AccountsDB").GetSection("Mongo").Value;
            if (conn == null)
            {
                throw new ArgumentException("Accounts MongoDB DataBase Not Defined in appsettings.json");
            }
            connection = conn;
        }
    }
}
