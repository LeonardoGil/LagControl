﻿using LagControlCLI.Arguments;
using LagControlCLI.Services.Interfaces;
using LagControlCLI.Utils.Extensions;
using LagFinanceLib.Domain;
using LagFinanceLib.Domain.Enum;
using LagFinanceLib.Interfaces;

namespace LagControlCLI.Services.Finance
{
    public class FinanceAddServices : IFinanceAddServices
    {
        private readonly IMovimentacaoRepository MovimentacaoRepository;

        private readonly IContaRepository ContaRepository;

        private readonly FinanceAddArgumentsEnum[] MandatoryArguments =
        {
            FinanceAddArgumentsEnum.d,
            FinanceAddArgumentsEnum.v
        };

        public FinanceAddServices(IMovimentacaoRepository movimentacaoRepository, 
                                  IContaRepository contaRepository)
        {
            MovimentacaoRepository = movimentacaoRepository;
            ContaRepository = contaRepository;
        }

        public void Process(string[] args)
        {
            if (!args.CheckMandatoryArguments(MandatoryArguments))
            {
                var arguments = MandatoryArguments.Select(arg => arg.ToString().Build());
                Console.WriteLine($"Necessario informar todos argumentos obrigatórios: {string.Join(" ", arguments)}");
                return;
            }

            try
            {
                var movimentacao = BuildMovimentacao(args);

                MovimentacaoRepository.Add(movimentacao);
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
                            movimentacao.Descricao = args.ProcessStringArgument<FinanceAddArgumentsEnum>(ref i);
                            break;

                        case FinanceAddArgumentsEnum.v:
                            movimentacao.Valor = args.ProcessDecimalArgument<FinanceAddArgumentsEnum>(ref i);
                            break;

                        case FinanceAddArgumentsEnum.dt:
                            movimentacao.Data = args.ProcessDateTimeArgument<FinanceAddArgumentsEnum>(ref i);
                            break;

                        case FinanceAddArgumentsEnum.c:
                            var descricaoConta = args.ProcessStringArgument<FinanceAddArgumentsEnum>(ref i);

                            movimentacao.ContaId = ContaRepository.Get()
                                                                  .FirstOrDefault(x => x.Descricao.ToUpper() == descricaoConta)?
                                                                  .Id ?? throw new Exception();
                            break;

                        default:
                            continue;
                    }
                }
                else
                {
                    throw new Exception($"Argumento inválido: {args[i]}");
                }
            }

            return movimentacao;
        }
    }
}
