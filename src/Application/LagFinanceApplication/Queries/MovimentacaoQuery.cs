using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Movimentacoes;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Queries
{
    public class MovimentacaoQuery(IMovimentacaoRepository movimentacaoRepository) : IMovimentacaoQuery
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository = movimentacaoRepository;

        public IList<MovimentacaoModel> ListarMovimentacao(ListarMovimentacaoQueryModel query)
        {
            var movimentacoesQuery = _movimentacaoRepository.Get().AsNoTracking();

            if (!string.IsNullOrEmpty(query.Descricao))
                movimentacoesQuery = movimentacoesQuery.Where(x => x.Descricao.ToUpper().Contains(query.Descricao.ToUpper()));

            if (query.ContaIds is not null && query.ContaIds.Any())
                movimentacoesQuery = movimentacoesQuery.Where(x => query.ContaIds.Contains(x.ContaId));

            if (query.CategoriaIds is not null && query.CategoriaIds.Any())
                movimentacoesQuery = movimentacoesQuery.Where(x => query.CategoriaIds.Contains(x.CategoriaId));

            if (query.Tipo.HasValue)
                movimentacoesQuery = movimentacoesQuery.Where(x => x.TipoMovimentacao == query.Tipo.Value);

            if (query.ApenasPendentes)
                movimentacoesQuery = movimentacoesQuery.Where(x => x.Pendente);

            if (query.DataInicial.HasValue && query.DataFinal.HasValue)
                movimentacoesQuery = movimentacoesQuery.Where(x => x.Data >= query.DataInicial.Value && x.Data <= query.DataFinal.Value);

            return movimentacoesQuery.Include(x => x.Conta)
                                     .Include(x => x.ContaTransferencia)
                                     .Include(x => x.Categoria)
                                     .Select(MapearMovimentacao)
                                     .ToList();
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
                                     .Include(x => x.Categoria)
                                     .OrderByDescending(x => x.DataCriacao)
                                     .Take(query.Total)
                                     .Select(MapearMovimentacao)
                                     .ToList();
        }

        private Func<Movimentacao, MovimentacaoModel> MapearMovimentacao = movimentacao =>
            new MovimentacaoModel
            {
                Id = movimentacao.Id,
                Conta = movimentacao.Conta.Descricao,
                Categoria = movimentacao.Categoria.Descricao,
                ContaTransferencia = movimentacao.ContaTransferencia?.Descricao ?? string.Empty,
                Data = movimentacao.Data,
                Descricao = movimentacao.Descricao,
                Observacao = movimentacao.Observacao,
                Pendente = movimentacao.Pendente,
                TipoMovimentacao = movimentacao.TipoMovimentacao,
                Valor = movimentacao.Valor
            };
    }
}
