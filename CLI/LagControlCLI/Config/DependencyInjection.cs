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
            builder.Services.AddSingleton<IMovimentacaoServices, MovimentacaoServices>();
            builder.Services.AddSingleton<IFinanceServices, FinanceServices>();
        }
    }
}
