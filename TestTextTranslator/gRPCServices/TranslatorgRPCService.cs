using Grpc.Core;
using Models;

namespace TestTextTranslator.gRPCServices
{
    public class TranslatorgRPCService : Translator.TranslatorBase
    {
        private readonly ILogger<TranslatorgRPCService> _logger;
        public TranslatorgRPCService(ILogger<TranslatorgRPCService> logger)
        {
            _logger = logger;
        }

        public override Task<TranslateReply> Translate(TranslateRequest request, ServerCallContext context)
        {
            return Task.FromResult(new TranslateReply
            {
                Data = "Hello " + request.Phrase
            });
        }
    }
}
