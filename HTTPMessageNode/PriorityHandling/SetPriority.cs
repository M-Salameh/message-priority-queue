namespace HTTPMessageNode.PriorityHandling
{
    public class SetPriority
    {
        /*
         * better to make priorities configurable from files !!
         */
        private static int MAX_PRIRITY = 5;
        private static int MIN_PRIRITY = 1;
        public static string setFinalPriority(ref Message message, string validatorAddress)
        {
            string res = DataBaseAccess.DBAccess.getPriority(ref message, validatorAddress);

            if (res == DataBaseAccess.DBAccess.ValidatorConnectionAndValidationError)
            {
                return res;
            }
            if (!res.Contains(DataBaseAccess.DBAccess.OK, StringComparison.OrdinalIgnoreCase))
            {
                return res;
            }

            int account_p = message.LocalPriority;

            int x = account_p + message.LocalPriority;
            if (x > MAX_PRIRITY) x = MAX_PRIRITY;
            if (x < MIN_PRIRITY && x != -1) x = MIN_PRIRITY;
            message.LocalPriority = x;

            return DataBaseAccess.DBAccess.OK;
        }
        /// we can complicate the mechanism as much as we want
    }
}
