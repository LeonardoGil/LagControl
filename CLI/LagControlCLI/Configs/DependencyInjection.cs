using LagControlCLI.Commands;
using LagControlCLI.Commands.Interfaces;
using LagControlCLI.Services.Finance;
using LagControlCLI.Services.Interfaces;
using LagFinanceLib.Interfaces;
using LagFinanceLib.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LagControlCLI.Configs
{
    public class DependencyInjection
    {
        public static void Inject(HostApplicationBuilder builder)
        {
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
