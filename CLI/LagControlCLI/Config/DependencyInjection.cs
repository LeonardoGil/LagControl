using LagControlCLI.Interface;
using LagControlCLI.Services;
using LagFinanceLib.Interface;
using LagFinanceLib.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LagControlCLI.Config
{
    public class DependencyInjection
    {
        public static void Inject(HostApplicationBuilder builder)
        {
            #region CLI
            builder.Services.AddSingleton<IFinanceServices, FinanceServices>();
            builder.Services.AddSingleton<IFinanceAddServices, FinanceAddServices>();
            #endregion

            #region Finance
            builder.Services.AddSingleton<IMovimentacaoServices, MovimentacaoRepository>();
            #endregion
        }
    }
}
