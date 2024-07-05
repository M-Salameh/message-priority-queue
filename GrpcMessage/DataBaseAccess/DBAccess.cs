
using Grpc.Net.Client;

namespace GrpcMessageNode.DataBaseAccess
{
    public class DBAccess
    {
        public static readonly string ValidatorConnectionAndValidationError = "Error On Validating";
        
        /// <summary>
        /// this OK must be in the reply from validation , so reply code should
        /// have the same string in it
        /// </summary>
        public static readonly string OK = "ok";


        /// <summary>
        /// check message for tag , Authentication , Quota perhaps from service validator with address
        /// passed as a parameter to the function
        /// </summary>
        /// <param name="message" > the message we received to check</param>
        /// <param name="validatorAddress"> The validator service address which as a mongodb service </param>
        /// <returns> validator reply which is ok if we can proceed with account priority</returns>
        public static string getPriority(ref Message message , string validatorAddress)
        {
            Console.WriteLine("Validating NOW IN GRPC !! ");
            ValidatorReply reply = ValidateAsync(message , validatorAddress);

            if (reply.ReplyCode == ValidatorConnectionAndValidationError)
            {
                return ValidatorConnectionAndValidationError;
            }
            if (!reply.ReplyCode.Contains(OK, StringComparison.OrdinalIgnoreCase))
            {
                return reply.ReplyCode;
            }
            message.LocalPriority = reply.AccountPriority;
            return OK;
        }

        private static ValidatorReply ValidateAsync(Message message, string validatorAddress)
        {
            using var channel = GrpcChannel.ForAddress(validatorAddress);
            var client = new Validate.ValidateClient(channel);
            MessageMetaData messageMeta = extractMetaData(message);
           
            Console.WriteLine("Calling GRPC for address = " + validatorAddress);
            
            try
            {
                var reply = client.ValidateMessageAsync(messageMeta);

                var ans = reply.GetAwaiter().GetResult();

                Console.WriteLine("OK , Validator DONE !!");

                return ans;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to validator - address = " + validatorAddress);

                return new ValidatorReply() { AccountPriority = -1, ReplyCode = ValidatorConnectionAndValidationError };
            }

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
