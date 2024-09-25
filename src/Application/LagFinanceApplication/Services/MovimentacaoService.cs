using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models;
using LagFinanceDomain.Domain;
using LagFinanceDomain.Enum;
using LagFinanceInfra.Interfaces;

namespace LagFinanceApplication.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public void AdicionarDespesa(AdicionarMovimentacaoModel model)
        {
            var movimentacao = new Movimentacao
            {
                CategoriaId = model.CategoriaId,
                ContaId = model.ContaId,

                Valor = model.Valor,
                Descricao = model.Descricao,
                Observacao = model.Observacao,
                Data = model.Data,

                TipoMovimentacao = TipoMovimentacaoEnum.Despesa
            };

            _movimentacaoRepository.Add(movimentacao);
            _movimentacaoRepository.SaveChanges();
        }
    }
}
