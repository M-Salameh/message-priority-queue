namespace GrpcMessageNode.DataBaseAccess
{
    public class MessageStorage
    {
        //use this class to store messages in database

        public static bool store(Message message , string DB)
        {
            Console.WriteLine(message.MsgId + " - is being stored in data base : " + DB);
            return true;
        }
    }
}
