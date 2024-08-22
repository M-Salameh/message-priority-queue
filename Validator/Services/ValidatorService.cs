using Grpc.Core;
using Validator;
using Validator.MongoDBAccess;

namespace Validator.Services
{
    public class ValidatorService : Validate.ValidateBase
    {
        private readonly ILogger<ValidatorService> _logger;
        public ValidatorService(ILogger<ValidatorService> logger)
        {
            _logger = logger;
        }

        public override Task<Reply> ValidateMessage(MessageMetaData messageMetaData , ServerCallContext context)
        {

            InformationHolder informationHolder = new InformationHolder();
            string res = informationHolder.checkMessage(messageMetaData);
            if ( res == informationHolder.OK)
            return Task.FromResult(new Reply
            {
                ReplyCode = "OK ok 200 + validated !! ",
                AccountPriority = 0
            }) ;
            else
            {
                return Task.FromResult(new Reply
                {
                    ReplyCode = res,
                    AccountPriority = -1
                });
            }
        }

    }
}