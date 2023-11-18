using LagControlCLI.Interface;
using LagFinanceLib.Interface;

namespace LagControlCLI.Services
{
    public class FinanceServices : IFinanceServices
    {
        private readonly IMovimentacaoServices MovimentacaoServices;

        public FinanceServices(IMovimentacaoServices movimentacaoServices)
        {
            MovimentacaoServices = movimentacaoServices;
        }

        public void On(string[] args)
        {
            Console.WriteLine("Inserindo Movimentacao");
            MovimentacaoServices.AddTest();

            Console.WriteLine("Visualizando Movimentacao");
            MovimentacaoServices.GetJsonTest();

            Console.WriteLine($"Module {ModulesEnum.Finance}");
        }
    }
}
