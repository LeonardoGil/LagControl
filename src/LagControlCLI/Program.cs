using LagControlCLI.Dialogs.Interfaces;
using LagControlCLI.Dialogs.Bases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace LagControlCLI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var culture = new CultureInfo("pt-BR");

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var builder = Host.CreateApplicationBuilder(args);
            
            builder.DependencyInjection();

            var app = builder.Build();

            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                DialogCancellation.CancelCurrent();
            };

            await Init(app);
        }

        static async Task Init(IHost app)
        {
            using var scope = app.Services.CreateScope();

            await scope.ServiceProvider.GetRequiredService<IMainDialog>().Show();
        }
    }
}
