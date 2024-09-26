using System.Collections;

namespace LagFinanceApplication.Models
{
    public class ConsultarSaldoQueryModel
    {
        public IEnumerable<Guid>? ContaIds { get; set; }
    }
}
