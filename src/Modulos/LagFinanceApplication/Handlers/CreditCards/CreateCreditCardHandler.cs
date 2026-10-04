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
                ClosingDay = request.ClosingDay,
                CreditLimit = request.CreditLimit,
                AccountId = request.AccountId
            };

            creditCardRepository.Add(card);

            await creditCardRepository.SaveChangesAsync(cancellationToken);

            return card.Id;
        }
    }
}
