namespace FinalMessagesConsumer.Initializer
{
    public class RedisInfoParser
    {
        public static void setInfo(ref IConfiguration config)
        {
            ReadRedisInfoParser.setInfo(ref config);    
            /*
             Write Consumer Groups Are The Same As Providers
             */
        }
    }
}
