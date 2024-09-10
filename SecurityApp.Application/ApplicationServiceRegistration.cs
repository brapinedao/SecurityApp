using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SecurityApp.Application.Behaviours;
using System.Reflection;

namespace SecurityApp.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {

            //Lee todas las clases que usan el automapper y las inyecta
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Busca todas las clases que usan el fluentvalidation y los inyecta
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            //Lee todas las clases que usan el mediatr y las inyecta
            services.AddMediatR(Assembly.GetExecutingAssembly());


            //Para los behaviours
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}

