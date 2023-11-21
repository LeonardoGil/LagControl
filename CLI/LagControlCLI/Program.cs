using LagControlCLI.Arguments;
using LagControlCLI.Commands;
using LagControlCLI.Configs;
using LagControlCLI.Utils.Extensions;
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

            Process(args, host);

            Console.ReadLine();
        }

        static void Process(string[] args, IHost host)
        {
            if (args.Any())
            {
                if (args[0].IsArgument<ProgramArguments>())
                {
                    Message.OnStart();
                }
                else
                {

                    var command = new Command(host);
                    command.Exec(args);
                }
            }
            else
            {
                Console.WriteLine("Nenhum argumento passado");
                Console.WriteLine("Aplicação será encerrada");
            }
        }
    }
}