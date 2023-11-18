using LagControlCLI.Interface;
using LagControlCLI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LagControlCLI
{
    public class Command
    {
        private readonly IFinanceServices FinanceServices;

        public Command(IHost host)
        {
            FinanceServices = host.Services.GetService<IFinanceServices>();
        }

        public void Exec(string[] args)
        {
            if (args.Any() && !string.IsNullOrEmpty(args[0]))
            {
                var sucess = Enum.TryParse(args[0], out ModulesEnum module);

                if (sucess)
                {
                    switch (module)
                    {
                        case ModulesEnum.Finance:
                            FinanceServices.On(args);
                            break;
                    }
                }
                else
                    Console.WriteLine("Modulo não encontrado");
            }
            else
                Console.WriteLine("Command Vazio.");


            Console.WriteLine("Encerrando operação");
        }
    }
}
