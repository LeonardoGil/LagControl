using LagControlCLI.Arguments;
using LagControlCLI.Interface;
using LagControlCLI.Utils.Extensions;
using LagFinanceLib.Domain;
using LagFinanceLib.Domain.Enum;
using LagFinanceLib.Interface;

namespace LagControlCLI.Services.Finance
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

            try
            {
                var movimentacao = BuildMovimentacao(args);

                MovimentacaoServices.Add(movimentacao);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private Movimentacao BuildMovimentacao(string[] args)
        {
            var movimentacao = new Movimentacao
            {
                Id = Guid.NewGuid(),
                Data = DateTime.Now,
                TipoMovimentacao = TipoMovimentacaoEnum.Despesa
            };

            for (int i = 0; i < args.Length; i++)
            {
                var sucess = args[i].IsArgument<FinanceAddArgumentsEnum>(out var argument);

                if (sucess)
                {
                    switch (argument)
                    {
                        case FinanceAddArgumentsEnum.d:
                            movimentacao.Descricao = DescricaoProcess(args, ref i);
                            break;

                        case FinanceAddArgumentsEnum.v:
                            movimentacao.Valor = ValorProcess(args, ref i);
                            break;

                        default:
                            continue;
                    }
                }
            }

            return movimentacao;
        }

        private string DescricaoProcess(string[] args, ref int index)
        {
            var value = args.GetValueFromArgument<FinanceAddArgumentsEnum>(index);

            if (value is null)
            {
                value = ArgumentExtensions.EnterAText("Informe uma descrição: ");
            }
            else
            {
                index++;
            }

            return value;
        }

        private decimal ValorProcess(string[] args, ref int index)
        {
            var value = args.GetValueFromArgument<FinanceAddArgumentsEnum>(index);

            var sucess = decimal.TryParse(value, out decimal result);

            if (sucess)
            {
                index++;
            }
            else
            {
                result = ArgumentExtensions.EnterADecimal("Informe um valor: ");
            }

            return result;
        }
    }
}
