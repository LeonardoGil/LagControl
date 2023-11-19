using LagFinanceLib.Database;
using LagFinanceLib.Domain;
using LagFinanceLib.Domain.Enum;
using LagFinanceLib.Interface;
using System.Text.Json;

namespace LagFinanceLib.Services
{
    public class MovimentacaoRepository : BaseRepository, IMovimentacaoServices
    {
        public void Add(Movimentacao movimentacao)
        {
            using (var context = new LagFinanceDbContext())
            {
                movimentacao.ContaId = context.Conta.First(x => x.Descricao == "Bradesco").Id;

                context.Movimentacao.Add(movimentacao);
                context.SaveChanges();
            }
        }
    }
}
