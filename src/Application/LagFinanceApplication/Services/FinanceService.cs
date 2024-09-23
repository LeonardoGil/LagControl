using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models;
using LagFinanceDomain.Domain;
using LagFinanceDomain.Enum;
using LagFinanceInfra.Interfaces;

namespace LagFinanceApplication.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public FinanceService(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public void AddMovimentacao(AddMovimentacaoModel model)
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
