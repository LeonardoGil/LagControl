using LagFinanceApplication.Commands.CreditCards;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using MediatR;

namespace LagFinanceApplication.Handlers.CreditCards
{
    public class CreateCreditCardHandler(ICreditCardRepository creditCardRepository) : IRequestHandler<CreateCreditCardCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
        {
            var card = new CreditCard
            {
                HolderName = request.HolderName,
                CreditLimit = request.CreditLimit,
                AccountId = request.AccountId,

                ClosingDay = request.ClosingDay ?? 1,
                DueDay = request.DueDay ?? 10
            };

            creditCardRepository.Add(card);

            await creditCardRepository.SaveChangesAsync(cancellationToken);

            return card.Id;
        }
    }
}
