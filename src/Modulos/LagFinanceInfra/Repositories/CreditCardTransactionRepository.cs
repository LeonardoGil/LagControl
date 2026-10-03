using LagBaseInfra;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repositories
{
    public class CreditCardTransactionRepository(LagFinanceDbContext context) : BaseRepository<LagFinanceDbContext, CreditCardTransaction>(context), ICreditCardTransactionRepository
    {
    }
}
