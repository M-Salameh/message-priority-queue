
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
        /// Validate Message by its MetaData (quota - api key ...) by a Validator Node
        /// </summary>
        /// <param name="message" > the message we received to check</param>
        /// <param name="validatorAddress"> The validator service address which as a mongodb service </param>
        /// <returns> string : Success or an Error</returns>
        public static string getPriority(ref Message message , string validatorAddress)
        {
            //Console.WriteLine("Validating NOW IN GRPC !! ");
            int x = message.LocalPriority;
            ValidatorReply reply = ValidateAsync(message , validatorAddress);

            if (reply.ReplyCode == ValidatorConnectionAndValidationError)
            {
                return ValidatorConnectionAndValidationError;
            }
            if (!reply.ReplyCode.Contains(OK, StringComparison.OrdinalIgnoreCase))
            {
                return reply.ReplyCode;
            }
            message.LocalPriority = x+reply.AccountPriority;
            return OK;
        }

        /// <summary>
        /// Calls the Validator Service and Gets the Reply
        /// </summary>
        /// <param name="message"></param>
        /// <param name="validatorAddress"></param>
        /// <returns>Validator Reply</returns>
        private static ValidatorReply ValidateAsync(Message message, string validatorAddress)
        {
            using var channel = GrpcChannel.ForAddress(validatorAddress);
            var client = new Validate.ValidateClient(channel);
            MessageMetaData messageMeta = extractMetaData(message);
           
            //Console.WriteLine("Calling GRPC for address = " + validatorAddress);
            
            try
            {
                var reply = client.ValidateMessageAsync(messageMeta);

                var ans = reply.GetAwaiter().GetResult();

                //Console.WriteLine("OK , Validator DONE !!");

                return ans;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error connecting to validator - address = " + validatorAddress);

                return new ValidatorReply() { AccountPriority = -1, ReplyCode = ValidatorConnectionAndValidationError };
            }

        }


        /// <summary>
        /// Extracts Message MetaData from a Message that Concerns us with the Validation Process
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Message Meta Data</returns>
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
