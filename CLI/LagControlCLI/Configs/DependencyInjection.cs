using LagControlCLI.Commands;
using LagControlCLI.Commands.Interfaces;
using LagControlCLI.Services.Finance;
using LagControlCLI.Services.Interfaces;
using LagFinanceLib.Database;
using LagFinanceLib.Interfaces;
using LagFinanceLib.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LagControlCLI.Configs
{
    public class DependencyInjection
    {
        public static void Inject(HostApplicationBuilder builder)
        {
            #region Context
            builder.Services.AddDbContext<LagFinanceDbContext>(opt => opt.UseSqlServer(@"Data Source=localhost;Initial Catalog=LagControl;Persist Security Info=True;User ID=sa;Password=P@ssw0rd!;Connect Timeout=900;TrustServerCertificate=true"));
            #endregion

            #region CLI
            builder.Services.AddSingleton<IFinanceCommand, FinanceCommand>();
            builder.Services.AddSingleton<IFinanceAddServices, FinanceAddServices>();
            #endregion

            #region Finance
            builder.Services.AddSingleton<IContaRepository, ContaRepository>();
            builder.Services.AddSingleton<IMovimentacaoRepository, MovimentacaoRepository>();
            #endregion
        }
    }
}
