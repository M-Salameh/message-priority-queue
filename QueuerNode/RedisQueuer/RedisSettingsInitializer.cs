using Scheduler.Initializer;
using StackExchange.Redis;

namespace Scheduler.RedisQueuer
{
    public class RedisSettingsInitializer
    {
        private static readonly string RedisURL = RedisInfoParser.connection;

        private static readonly string Syriatel = RedisInfoParser.Syriatel;
        private static readonly string MTN = RedisInfoParser.MTN;
        private static readonly int LEVELS = 6;
        private static int StreamMaxLength = 100000000;
        public static IDatabase db = null;
        public readonly string RedisConnectionError = "Error Writing to Redis";

        /// <summary>
        /// Connects to Redis Stream With Streams for Each Priority and create consuming groups
        /// if not created
        /// </summary>
        public static void init()
        {

            var redis = ConnectionMultiplexer.Connect(RedisURL);
            db = redis.GetDatabase();
            for (int i = 1; i < LEVELS; i++)
            {
                try
                {
                    bool k1 = db.StreamCreateConsumerGroup(Syriatel + "_" + i.ToString(),
                        "SYS_MSGS",
                        0,
                        true);

                    bool k2 = db.StreamCreateConsumerGroup(MTN + "_" + i.ToString(),
                        "SYS_MSGS",
                        0,
                        true);


                    if (k1 && k2)
                    {
                        Console.WriteLine("OK");
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

        }
    }
}
