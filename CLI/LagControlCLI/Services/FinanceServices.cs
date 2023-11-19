using LagControlCLI.Arguments;
using LagControlCLI.Interface;

namespace LagControlCLI.Services
{
    public class FinanceServices : IFinanceServices
    {
        private readonly IFinanceAddServices FinanceAddServices;

        public FinanceServices(IFinanceAddServices financeAddServices)
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

            var sucess = Enum.TryParse(args[1].ToLower(), out FinanceArgumentsEnum argument);

            if (!sucess)
            {
                Console.WriteLine("FinanceArgument invalido");
                return;
            }

            var arguments = args.Skip(1).ToArray();

            switch (argument)
            {
                case FinanceArgumentsEnum.add:
                    FinanceAddServices.On(arguments);
                    break;
            }
        }
    }
}