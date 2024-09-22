using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LagControlForms.Forms;
using LagFinanceInfra.Repositories;
using LagFinanceInfra.Interfaces;
using Microsoft.EntityFrameworkCore;
using LagFinanceInfra.Database;

namespace LagControlForms.Configs
{
    public static class DependencyInjection
    {
        public static HostApplicationBuilder Inject(this HostApplicationBuilder builder)
        {
            #region Context
            builder.Services.AddDbContext<LagFinanceDbContext>(opt => opt.UseSqlServer(@"Data Source=localhost;Initial Catalog=LagControl;Persist Security Info=True;User ID=sa;Password=P@ssw0rd!;Connect Timeout=900;TrustServerCertificate=true"));
            #endregion

            #region Finance
            builder.Services.AddSingleton<IContaRepository, ContaRepository>();
            builder.Services.AddSingleton<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddSingleton<IMovimentacaoRepository, MovimentacaoRepository>();
            #endregion

            #region Forms
            builder.Services.AddSingleton<MainForm>();
            #endregion

            return builder;
        }
    }
}
