using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Movimentacoes;
using LagFinanceInfra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Queries
{
    public class MovimentacaoQuery : IMovimentacaoQuery
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoQuery(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public IList<MovimentacaoModel> ListarUltimasMovimentacoes(ListarUltimasMovimentacoesQueryModel query)
        {
            var movimentacoesQuery = _movimentacaoRepository.Get().AsNoTracking();

            if (query.ContaIds is not null)
            {
                movimentacoesQuery = movimentacoesQuery.Where(x => query.ContaIds.Contains(x.Id));
            }

            return movimentacoesQuery.Include(x => x.Conta)
                                     .Include(x => x.ContaTransferencia)
                                     .OrderByDescending(x => x.DataCriacao)
                                     .Take(query.Total)
                                     .Select(mov => new MovimentacaoModel
                                     {
                                         Conta = mov.Conta.Descricao,
                                         Categoria = mov.Categoria.Descricao,
                                         ContaTransferencia = mov.ContaTransferencia.Descricao,
                                         Data = mov.Data,
                                         Descricao = mov.Descricao,
                                         Observacao = mov.Observacao,
                                         Pendente = mov.Pendente,
                                         TipoMovimentacao = mov.TipoMovimentacao,
                                         Valor = mov.Valor
                                     }).ToList();
        }
    }
}
