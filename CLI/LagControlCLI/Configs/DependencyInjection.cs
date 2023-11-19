using LagControlCLI.Commands;
using LagControlCLI.Commands.Interfaces;
using LagControlCLI.Services.Finance;
using LagControlCLI.Services.Interfaces;
using LagFinanceLib.Interface;
using LagFinanceLib.Services;
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
            builder.Services.AddSingleton<IMovimentacaoServices, MovimentacaoRepository>();
            #endregion
        }
    }
}
