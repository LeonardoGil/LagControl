using LagControlCLI.Commands.Enums;
using LagControlCLI.Interface;

namespace LagControlCLI.Commands
{
    public class FinanceCommand : IFinanceServices
    {
        private readonly IFinanceAddServices FinanceAddServices;

        public FinanceCommand(IFinanceAddServices financeAddServices)
        {
            FinanceAddServices = financeAddServices;
        }

        public void On(string[] args)
        {
            Console.WriteLine("LagControlCLI.Services.FinanceServices.On()");

            if (args.Length < 2 || string.IsNullOrEmpty(args[1]))
            {
                Console.WriteLine("FinanceArgument não informado");
                return;
            }

            var sucess = Enum.TryParse(args[1].ToLower(), out FinanceCommandEnum argument);

            if (!sucess)
            {
                Console.WriteLine("FinanceArgument invalido");
                return;
            }

            var arguments = args.Skip(2).ToArray();

            switch (argument)
            {
                case FinanceCommandEnum.add:
                    FinanceAddServices.On(arguments);
                    break;
            }
        }
    }
}