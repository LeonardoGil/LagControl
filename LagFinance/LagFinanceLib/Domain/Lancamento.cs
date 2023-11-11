using System.Runtime.InteropServices;

namespace LagFinanceLib.Domain
{
    public class Lancamento
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public Guid ContaId { get; set; }

        public decimal Valor { get; set; }

        public DateOnly Data { get; set; }
    }
}
