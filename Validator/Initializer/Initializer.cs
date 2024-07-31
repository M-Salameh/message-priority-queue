namespace Validator.Initializer
{
    public class Initializer
    {
        public static void init(ref IConfiguration conf)
        {
            AccountsDBParser.setAccountsDB(ref conf);
            ServiceNameParser.setServiceName(ref conf);
        }
    }
}
