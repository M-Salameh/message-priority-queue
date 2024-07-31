namespace Scheduler.Initializer
{
    public class Initializer
    {
        public static void init(ref IConfiguration conf)
        {
            MessagesMongoDBParser.setAccountsDB(ref conf);
            ServiceNameParser.setServiceName(ref conf);
            RedisInfoParser.setInfo(ref conf);    
        }
    }
}
