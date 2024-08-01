namespace ScheduledMessagesHandler.Initializer
{
    public class Initializer
    {
        public static void init(ref IConfiguration conf)
        {
            RedisInfoParser.setInfo(ref conf);    
            MessagesMongoDBParser.setStorageDB(ref conf);
        }
    }
}
