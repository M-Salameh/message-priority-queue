
using Grpc.Net.Client;

namespace GrpcMessageNode.DataBaseAccess
{
    public class DBAccess
    {

        /// <summary>
        /// check message for tag , Authentication , Quota perhaps from service validator with address
        /// passed as a parameter to the function
        /// </summary>
        /// <param name="message" > the message we received to check</param>
        /// <param name="validatorAddress"> The validator service address which as a mongodb service </param>
        /// <returns> validator reply which is ok if we can proceed with account priority</returns>
        public static int getPriority(ref Message message , string validatorAddress)
        {
            //Console.WriteLine("Validating NOW IN GRPC !! ");
            ValidatorReply reply = ValidateAsync(message , validatorAddress);

            if (reply == null)
            {
                return -1;
            }
            if (!reply.ReplyCode.Contains("ok"))
            {
                return -1;
            }

            return reply.AccountPriority;
        }

        private static ValidatorReply ValidateAsync(Message message, string validatorAddress)
        {
            using var channel = GrpcChannel.ForAddress(validatorAddress);
            var client = new Validate.ValidateClient(channel);
            MessageMetaData messageMeta = extractMetaData(message);
            Console.WriteLine("Calling GRPC for address = " + validatorAddress);
            var reply =  client.ValidateMessageAsync(messageMeta);
            
            var ans = reply.GetAwaiter().GetResult();
            
            return ans;

        }

        private static MessageMetaData extractMetaData(Message message)
        {
            MessageMetaData metaData = new MessageMetaData();
            metaData.Tag = message.Tag;
            metaData.ApiKey = message.ApiKey;
            metaData.ClientID = message.ClientID;
            return metaData;
        }
    }
}
