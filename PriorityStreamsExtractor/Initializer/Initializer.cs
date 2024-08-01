
namespace PriorityStreamsExtractor.Initializer
{
    public class Initializer
    {
        public static void init(ref IConfiguration conf)
        {
            RedisInfoParser.setInfo(ref conf);   
            ProvidersInfoParser.setInfo(ref conf);
        }
    }
}
