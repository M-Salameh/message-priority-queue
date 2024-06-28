namespace GrpcMessageNode.PriorityHandling
{
    public class SetPriority
    {
        /*
         * better to make priorities configurable from files !!
         */
        private static int MAX_PRIRITY = 5;
        private static int MIN_PRIRITY = 1;
        public static bool setFinalPriority(Message message)
        {
            int account_p = DataBaseAccess.DBAccess.getPriorityAndStoreMessage(message);
            int x = account_p + message.LocalPriority;
            if (x > MAX_PRIRITY) x = MAX_PRIRITY;
            if (x < MIN_PRIRITY && x!=-1) x = MIN_PRIRITY;
            message.LocalPriority = x;
            if (x == -1) return false;
            return true;    
        }
        /// we can complicate the mechanism as much as we want
    }
}
