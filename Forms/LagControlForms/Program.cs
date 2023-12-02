using AutoMapper;
using LagControlForms.Configs;
using LagFinanceLib.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LagControlForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var builder = Host.CreateApplicationBuilder()
                              .Profiles()
                              .Inject();

            var host = builder.Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Run(host);
        }

        static void Run(IHost host)
        {
            var form = new MovimentacaoForm(host.Services.GetService<IMapper>(),
                                            host.Services.GetService<IMovimentacaoRepository>());

            Application.Run(form);
        }
    }
}