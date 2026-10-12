using LagFinanceApplication.Dtos.CreditCards;
using LagFinanceApplication.Queries.CreditCards;
using LagFinanceDomain.Enums;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.CreditCards
{
    public class CreditCardListHandler(ICreditCardRepository creditCardRepository) : IRequestHandler<CreditCardListQuery, IList<CreditCardListDto>>
    {
        public async Task<IList<CreditCardListDto>> Handle(CreditCardListQuery request, CancellationToken cancellationToken)
        {
            var query = creditCardRepository.Get()
                                            .AsNoTracking()
                                            .Include(c => c.Invoices!.Where(x => x.Status == CreditCardInvoiceStatusEnum.Open))
                                            .ThenInclude(i => i.Transactions)
                                            .Include(c => c.Account)
                                            .Select(c => new CreditCardListDto
                                            {
                                                Account = c.Account!.Description,
                                                HolderName = c.HolderName,
                                                CreditLimit = c.CreditLimit,
                                                AvailableLimit = c.CreditLimit - c.Invoices!.SelectMany(x => x.Transactions!).Sum(t => t.Amount)
                                            });
                      

            return await query.ToListAsync(cancellationToken);
        }
    }
}
