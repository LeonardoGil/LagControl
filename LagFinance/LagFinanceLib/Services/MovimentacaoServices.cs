using LagFinanceLib.Database;
using LagFinanceLib.Domain;
using LagFinanceLib.Domain.Enum;
using LagFinanceLib.Interface;
using System.Text.Json;

namespace LagFinanceLib.Services
{
    public class MovimentacaoServices : BaseServices, IMovimentacaoServices
    {
        public void Add()
        {
            var movimentacaoTeste = new Movimentacao
            {
                Id = Guid.NewGuid(),
                ContaId = Guid.Parse("E389E09E-FB13-4F58-846D-4E9D9FA00813"),
                Data = DateTime.Now,
                Valor = 2,
                TipoMovimentacao = TipoMovimentacaoEnum.Despesa,
                Descricao = "Teste"
            };

            using (var context = new LagFinanceDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Movimentacao.Add(movimentacaoTeste);
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Falha: {e.InnerException}");
                }

            }
        }
    }
}
