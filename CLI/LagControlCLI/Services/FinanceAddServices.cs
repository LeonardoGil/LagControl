using LagControlCLI.Arguments;
using LagControlCLI.Interface;
using LagControlCLI.Utils.Extensions;
using LagFinanceLib.Domain;
using LagFinanceLib.Domain.Enum;
using LagFinanceLib.Interface;

namespace LagControlCLI.Services
{
    public class FinanceAddServices : IFinanceAddServices
    {
        private readonly IMovimentacaoServices MovimentacaoServices;

        public FinanceAddServices(IMovimentacaoServices movimentacaoServices)
        {
            MovimentacaoServices = movimentacaoServices;
        }

        public void On(string[] args)
        {
            var arguments = Enum.GetNames(typeof(FinanceAddArgumentsEnum));

            if (!arguments.All(argument => args.Contains(argument.Build())))
            {
                Console.WriteLine("Necessario informar todos argumentos (-d -v)");
                return;
            }

            var movimentacao = new Movimentacao
            {
                Id = Guid.NewGuid(),
                Data = DateTime.Now,
                TipoMovimentacao = TipoMovimentacaoEnum.Despesa
            };

            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    var sucess = args[i].IsArgument<FinanceAddArgumentsEnum>(out var argument);

                    if (sucess)
                    {
                        switch (argument)
                        {
                            case FinanceAddArgumentsEnum.d:
                                movimentacao.Descricao = DescricaoExec(args, i);
                                i++;
                                break;

                            case FinanceAddArgumentsEnum.v:
                                break;

                            default:
                                continue;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private string DescricaoExec(string[] args, int index)
        {
            var value = args.GetValueFromArgument<FinanceAddArgumentsEnum>(index);

            if (value is null)
            {
                value = ArgumentExtensions.EnterAText("Informe uma descrição: ");
            }

            return value;
        }
    }
}
