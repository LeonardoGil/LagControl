using LagBaseInfra;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repositories
{
    public class CreditCardRepository(LagFinanceDbContext context) : BaseRepository<LagFinanceDbContext, CreditCard>(context), ICreditCardRepository
    {
    }
}
