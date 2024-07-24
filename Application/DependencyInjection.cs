using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            // Configure MediatR
            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            // Configure FluentValidation
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
