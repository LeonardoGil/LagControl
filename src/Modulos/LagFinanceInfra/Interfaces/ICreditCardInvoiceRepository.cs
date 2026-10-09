using LagBaseInfra;
using LagFinanceDomain.Entities;

namespace LagFinanceInfra.Interfaces
{
    public interface ICreditCardInvoiceRepository : IBaseRepository<CreditCardInvoice>
    {
        Task<CreditCardInvoice?> GetInvoiceByReferenceDateAsync(int month, int year, Guid creditCardId);

        Task<CreditCardInvoice?> GetInvoiceByTransactionAsync(DateTime transactionDate, Guid creditCardId);
    }
}
