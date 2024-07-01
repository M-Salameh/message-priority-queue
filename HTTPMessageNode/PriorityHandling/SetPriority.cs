namespace HTTPMessageNode.PriorityHandling
{
    public class SetPriority
    {
        /*
         * better to make priorities configurable from files !!
         */
        private static int MAX_PRIRITY = 5;
        private static int MIN_PRIRITY = 1;
        public static bool setFinalPriority(ref Message message , string validatorAddress)
        {
            int account_p = DataBaseAccess.DBAccess.getPriority(ref message , validatorAddress);
            if (account_p == -1) return false;
            int x = account_p + message.LocalPriority;
            if (x > MAX_PRIRITY) x = MAX_PRIRITY;
            if (x < MIN_PRIRITY && x!=-1) x = MIN_PRIRITY;
            message.LocalPriority = x;
            
            return true;    
        }
        /// we can complicate the mechanism as much as we want
    }
}
