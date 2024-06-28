
using GrpcMessageNode.DataBaseAccess;


namespace GrpcMessageNode.DataBaseAccess
{
    public static class DBAccess
    {
        /// <summary>
        ///  this class encapsulates MessageStorage and ProcessMessage classed and through it
        ///  we access them as a type of layering
        /// </summary>
        private static string messageStorageURL = "db that stores messagees";
        private static string accountStorageURL = "db that holds information about account + quota";

        public static int getPriorityAndStoreMessage(Message message)
        {
            //authenticate and something else with logic and booleans to ensure all operation is done
            MessageStorage.store(message, messageStorageURL);
            int x = ProcessMessage.getPriority(message, accountStorageURL);
            // if something wrong retrn -1
            return x;
        }

    }
}
