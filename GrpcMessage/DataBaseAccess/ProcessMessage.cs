namespace GrpcMessageNode.DataBaseAccess
{
    public class ProcessMessage
    {
        /// use this class to authenticate and process logic on message receipt 
        /// get the account priority and use it to determine total priority before
        /// sending the message to coordinator and queuing
        /// 
        public static int getPriority(Message message , string DB)
        {
            string accId = message.ClientID;
            Console.WriteLine("Getting priority of account " + accId + " from DataBase : " + DB);
            int x = 1;
            return x;
        }
        
    }
}
