using FluentValidation;
using MediatR;

namespace SecurityApp.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Evaluamos si ya hay alguna validacion
            if (_validators.Any())
            {
                //Buscamos todas las validaciones y detenemos el flujo del request
                var context = new ValidationContext<TRequest>(request);

                //Ejecuta las validaciones en el pipeline
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                //Guardamos la totalidad de errores
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                //Si hay alguna excepcion o error detenemos el flujo
                if (failures.Count != 0)
                {
                    //Le pasamos los errores al exception creado anteriormente
                    throw new ValidationException(failures);
                }
            }
            //Continua el flujo si no hay error de validacion
            return await next();
        }
    }
}
