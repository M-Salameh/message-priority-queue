using Grpc.Core;
using Validator;

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
            // do some work  with /DataBase
            return Task.FromResult(new Reply
            {
                ReplyCode = "OK ok 200 + validated !! ",
                AccountPriority = 3
            }) ;
        }

    }
}