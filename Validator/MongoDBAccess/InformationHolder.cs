using Validator.Initializer;

namespace Validator.MongoDBAccess
{
    public class InformationHolder
    {
        private static readonly string URL = AccountsDBParser.connection;
        private static readonly string DBName = AccountsDBParser.DBName;
        private static readonly string collection = AccountsDBParser.collection;

        public static void checkMessage(MessageMetaData metaData)
        {
            //check for auther + authen + quota
        }
    }
}
