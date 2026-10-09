using LagBaseInfra;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Repositories
{
    public class CreditCardInvoiceRepository(LagFinanceDbContext context) : BaseRepository<LagFinanceDbContext, CreditCardInvoice>(context), ICreditCardInvoiceRepository
    {
        public async Task<CreditCardInvoice?> GetInvoiceByReferenceDateAsync(int month, int year, Guid creditCardId)
        {
            return await _context.CreditCardInvoice.Where(i => i.CreditCardId == creditCardId)
                                                   .Where(i => i.ReferenceMonth == month && i.ReferenceYear == year)
                                                   .FirstOrDefaultAsync();
        }

        public async Task<CreditCardInvoice?> GetInvoiceByTransactionAsync(DateTime transactionDate, Guid creditCardId)
        {
            return await _context.CreditCardInvoice.Where(i => i.CreditCardId == creditCardId)
                                                   .Where(i => transactionDate.Date < i.ClosingDate.Date)
                                                   .Where(i => transactionDate.Date >= i.OpeningDate.Date)
                                                   .FirstOrDefaultAsync();
        }
    }
}
