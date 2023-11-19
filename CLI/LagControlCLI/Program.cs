using LagControlCLI.Commands;
using LagControlCLI.Configs;
using Microsoft.Extensions.Hosting;
 
// Application LAG_CONTROL_CLI
// Para gerenciamento pessoal de Leonardo Albuquerque Gil através de linhas de Comando
// Projeto iniciado no dia 29/10/23.

namespace LagControlCLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            DependencyInjection.Inject(builder);

            var host = builder.Build();

            Message.OnStart();

            var command = new Command(host);
            command.Exec(args);
        }
    }
}