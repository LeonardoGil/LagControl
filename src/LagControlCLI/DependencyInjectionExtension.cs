using LagControlCLI.Behaviors;
using LagControlCLI.Dialogs;
using LagControlCLI.Dialogs.Finances;
using LagControlCLI.Dialogs.Finances.Accounts;
using LagControlCLI.Dialogs.Finances.Categories;
using LagControlCLI.Dialogs.Finances.Reports;
using LagControlCLI.Dialogs.Finances.Transactions;
using LagControlCLI.Dialogs.Interfaces;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagFinanceApplication;
using LagFinanceInfra.Database;
using LagFinanceInfra.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;

namespace LagControlCLI
{
    internal static class DependencyInjectionExtension
    {
        internal static IHostApplicationBuilder DependencyInjection(this IHostApplicationBuilder builder)
        {
            builder.Services.AddLagControlCLI();

            // Database
            var connectionString = builder.Configuration.GetConnectionString("DbContext") ?? throw new Exception("ConnectionString n�o localizada");
            builder.Services.AddDbContext<LagFinanceDbContext>(opt => opt.UseSqlServer(connectionString, options => options.MigrationsHistoryTable("__MigrationsHistory", "Finance")));

            // Modules
            builder.Services.AddLagFinanceApplication();
            builder.Services.AddLagFinanceInfra();

            // FluentValidation
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return builder;
        }

        internal static IServiceCollection AddLagControlCLI(this IServiceCollection services)
        {
            services.AddSingleton(AnsiConsole.Console);
            services.AddScoped<IMainDialog, MainDialog>();
            services.AddScoped<IMainFinanceDialog, MainFinanceDialog>();
            services.AddScoped<IAddTransactionDialog, AddTransactionDialog>();
            services.AddScoped<IAddTransferTransactionDialog, AddTransferTransactionDialog>();
            services.AddScoped<IAddCategoryDialog, AddCategoryDialog>();
            services.AddScoped<ICategoryDialog, CategoryDialog>();
            services.AddScoped<IEditCategoryDialog, EditCategoryDialog>();
            services.AddScoped<IEditTransactionDialog, EditTransactionDialog>();
            services.AddScoped<ITransactionDialog, TransactionDialog>();
            services.AddScoped<IListTransactionFilterDialog, ListTransactionFilterDialog>();
            services.AddScoped<IShowTransactionDetailsDialog, ShowTransactionDetailsDialog>();
            services.AddScoped<IAccountsDialog, AccountsDialog>();
            services.AddScoped<IAddAccountDialog, AddAccountDialog>();
            services.AddScoped<IShowAccountDetailsDialog, ShowAccountDetailsDialog>();
            services.AddScoped<IConfirmPendingTransactionDialog, ConfirmPendingTransactionDialog>();
            services.AddScoped<IListTransactionDialog, ListTransactionDialog>();
            services.AddScoped<IReportsDialog, ReportsDialog>();
            services.AddScoped<IStatementReportDialog, StatementReportDialog>();

            return services;
        }
    }
}
