using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Dtos.Transactions;
using LagFinanceApplication.Queries.Accounts;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Accounts
{
    public class ExpensesByCategoryHandler(ICategoryRepository categoryRepository, ITransactionRepository transactionRepository) : IRequestHandler<ExpensesByCategoryQuery, ExpensesByCategoryDto>
    {
        public async Task<ExpensesByCategoryDto> Handle(ExpensesByCategoryQuery query, CancellationToken cancellationToken)
        {
            var queryable = categoryRepository.Get().Join(transactionRepository.Get(),
                                                        category => category.Id,
                                                        transaction => transaction.CategoryId,
                                                        (category, transaction) => new { category, transaction }).GroupBy(x => x.category);

            return new ExpensesByCategoryDto
            {
                ExpensesByCategoryGroup = await queryable.Select(c => new ExpensesByCategoryGroupDto
                {
                    Category = c.Key.Description,
                    Type = c.Key.Type,
                    Transactions = c.Select(x => new TransactionGridDto
                    {
                        Id = x.transaction.Id,
                        Date = x.transaction.Date,
                        Description = x.transaction.Description,
                        Amount = x.transaction.Amount,
                        Type = x.transaction.TransactionType,
                        Category = x.category.Description,
                        Account = x.transaction.Account!.Description,
                        BalanceAmount = x.transaction.BalanceAmount()
                    })
                    .ToList()
                })
                .ToListAsync(cancellationToken: cancellationToken)
            };
        }
    }
}

