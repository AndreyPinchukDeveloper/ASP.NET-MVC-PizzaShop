using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using ShopApplication.Common.Behaviors;

namespace ShopApplication
{
    public static class DependencyInjection
    {
        
        public static IServiceCollection AddApplication(this IServiceCollection services)
        { 
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
