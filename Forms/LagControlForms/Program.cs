using LagControlForms.Configs;
using LagControlForms.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LagControlForms
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            var builder = Host.CreateApplicationBuilder()
                              .Profiles()
                              .Inject();

            var host = builder.Build();
            ServiceProvider = host.Services;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            Application.Run(ServiceProvider.GetRequiredService<MainForm>());

            //Application.Run(ServiceProvider.GetRequiredService<MovimentacaoForm>());
        }
    }
}