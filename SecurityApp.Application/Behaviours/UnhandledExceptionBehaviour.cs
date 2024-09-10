using MediatR;
using Microsoft.Extensions.Logging;

namespace SecurityApp.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                //Si todo es correcto el flujo del pipeline continua
                return await next();
            }
            catch (Exception exception)
            {
                //Si ocurre un error se captura el nombre del request y se nombra el error
                var requestName = typeof(TRequest).Name;
                _logger.LogError(exception, "Application Request: Exception error for the request {Name} {@Request} ", requestName, request);
                throw;
            }
        }
    }
}
