using LagFinanceInfra.Interfaces;
using LagFinanceInfra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LagFinanceInfra.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddLagFinanceInfra(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            services.AddScoped<ICreditCardTransactionRepository, CreditCardTransactionRepository>();
            services.AddScoped<ICreditCardInvoiceRepository, CreditCardInvoiceRepository>();
            return services;
        }
    }
}
