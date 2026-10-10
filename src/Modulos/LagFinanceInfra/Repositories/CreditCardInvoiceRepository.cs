using LagBaseInfra;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repositories
{
    public class CreditCardInvoiceRepository(LagFinanceDbContext context) : BaseRepository<LagFinanceDbContext, CreditCardInvoice>(context), ICreditCardInvoiceRepository
    {
    }
}
