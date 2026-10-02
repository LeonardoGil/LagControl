using LagControlCLI.Behaviors;
using LagControlCLI.Dialogs;
using LagControlCLI.Dialogs.Finances;
using LagControlCLI.Dialogs.Finances.Accounts;
using LagControlCLI.Dialogs.Finances.Categories;
using LagControlCLI.Dialogs.Finances.Transactions;
using LagControlCLI.Dialogs.Finances.Reports;
using LagControlCLI.Dialogs.Interfaces;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagFinanceApplication;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;
using LagFinanceInfra.Repositories;
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
            // Local
            builder.Services.AddSingleton(AnsiConsole.Console);
            builder.Services.AddScoped<IMainDialog, MainDialog>();
            builder.Services.AddScoped<IMainFinanceDialog, MainFinanceDialog>();
            builder.Services.AddScoped<IAddTransactionDialog, AddTransactionDialog>();
            builder.Services.AddScoped<IAddTransferTransactionDialog, AddTransferTransactionDialog>();
            builder.Services.AddScoped<IAddCategoryDialog, AddCategoryDialog>();
            builder.Services.AddScoped<ICategoryDialog, CategoryDialog>();
            builder.Services.AddScoped<IEditCategoryDialog, EditCategoryDialog>();
            builder.Services.AddScoped<IEditTransactionDialog, EditTransactionDialog>();
            builder.Services.AddScoped<ITransactionDialog, TransactionDialog>();
            builder.Services.AddScoped<IListTransactionFilterDialog, ListTransactionFilterDialog>();
            builder.Services.AddScoped<IShowTransactionDetailsDialog, ShowTransactionDetailsDialog>();
            builder.Services.AddScoped<IAccountsDialog, AccountsDialog>();
            builder.Services.AddScoped<IAddAccountDialog, AddAccountDialog>();
            builder.Services.AddScoped<IShowAccountDetailsDialog, ShowAccountDetailsDialog>();
            builder.Services.AddScoped<IConfirmPendingTransactionDialog, ConfirmPendingTransactionDialog>();
            builder.Services.AddScoped<IListTransactionDialog, ListTransactionDialog>();
            builder.Services.AddScoped<IReportsDialog, ReportsDialog>();
            builder.Services.AddScoped<IStatementReportDialog, StatementReportDialog>();

            // Database
            var connectionString = builder.Configuration.GetConnectionString("DbContext") ?? throw new Exception("ConnectionString n�o localizada");
            builder.Services.AddDbContext<LagFinanceDbContext>(opt => opt.UseSqlServer(connectionString, options => options.MigrationsHistoryTable("__MigrationsHistory", "Finance")));

            // Service
            builder.Services.AddLagFinanceApplication();

            // Repository
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

            // FluentValidation
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return builder;
        }
    }
}
