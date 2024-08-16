using Validator.Initializer;

namespace Validator.MongoDBAccess
{
    public class InformationHolder
    {
        private readonly string URL = AccountsDBParser.connection;
        private readonly string DBName = AccountsDBParser.DBName;
        private readonly string collection = AccountsDBParser.collection;

        public  void checkMessage(MessageMetaData metaData)
        {
            //check for auther + authen + quota
        }
    }
}
