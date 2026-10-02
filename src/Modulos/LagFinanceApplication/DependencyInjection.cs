using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LagFinanceApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLagFinanceApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(LagFinanceApplicationAssemblyReference).Assembly);
            services.AddValidatorsFromAssembly(typeof(LagFinanceApplicationAssemblyReference).Assembly);
            
            return services;
        }
    }
}

