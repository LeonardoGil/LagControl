using MediatR;

namespace LagFinanceApplication.Commands.CreditCards
{
    public record CreateCreditCardCommand : IRequest<Guid>
    {
        public required string HolderName { get; set; }

        public required int ClosingDay { get; set; }

        public required decimal CreditLimit { get; set; }

        public required Guid AccountId { get; set; }
    }
}
