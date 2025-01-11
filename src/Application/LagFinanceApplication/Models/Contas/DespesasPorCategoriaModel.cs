using LagFinanceApplication.Models.Movimentacoes;
using LagFinanceDomain.Entities;
using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Models.Contas
{
    public class DespesasPorCategoriaModel
    {
        public string Conta { get; set; }

        public IList<DespesasPorCategoriaGroupModel> DespesasPorCategoriaGroup { get; set; }

        public DespesasPorCategoriaModel(Conta conta)
        {
            ArgumentNullException.ThrowIfNull(conta);

            var movimentacoes = conta.Movimentacoes.Where(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Despesa && !x.Pendente);

            Conta = conta.Descricao;
            DespesasPorCategoriaGroup = movimentacoes.GroupBy(x => new { x.CategoriaId, x.Categoria.Descricao })
                                                     .Select(x => new DespesasPorCategoriaGroupModel
                                                     {
                                                         Categoria = x.Key.Descricao,
                                                         ValorTotal = x.Sum(x => x.Valor),
                                                         Movimentacoes = x.Select(mov => new MovimentacaoModel
                                                         {
                                                             Id = mov.Id,
                                                             Conta = mov.Conta.Descricao,
                                                             Categoria = mov.Categoria.Descricao,
                                                             Data = mov.Data,
                                                             Descricao = mov.Descricao,
                                                             Observacao = mov.Observacao,
                                                             TipoMovimentacao = mov.TipoMovimentacao,
                                                             Valor = mov.Valor
                                                         })
                                                         .ToList()
                                                     })
                                                     .ToList();
        }
    }

    public class DespesasPorCategoriaGroupModel
    {
        public string Categoria { get; set; }

        public decimal ValorTotal { get; set; }

        public IList<MovimentacaoModel> Movimentacoes { get; set; }
    }
}
