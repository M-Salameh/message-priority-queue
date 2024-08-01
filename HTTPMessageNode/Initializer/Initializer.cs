namespace HTTPMessageNode.Initializer
{
    public class Initializer
    {
        public static void init(ref IConfiguration conf)
        {
            ServiceNameParser.setServiceName(ref conf);
        }
    }
}
