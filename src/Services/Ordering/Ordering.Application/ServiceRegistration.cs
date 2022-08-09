using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Behaviours;
using System.Reflection;

namespace Ordering.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // using reflection, automapper will look for classes that inherits from Profile 

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // Register fluent validators

            // using reflection, fluent validator will look for classes that inherits from AbstractValidator
            services.AddMediatR(Assembly.GetExecutingAssembly()); // Register mediatR

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
