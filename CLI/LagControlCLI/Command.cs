using LagControlCLI.Services;

namespace LagControlCLI
{
    public class Command
    {
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
                            new FinanceServices().On(args);
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
