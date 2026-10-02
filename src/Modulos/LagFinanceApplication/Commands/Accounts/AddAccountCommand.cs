using MediatR;

namespace LagFinanceApplication.Commands.Accounts
{
    public record AddAccountCommand : IRequest<Unit>
    {
        public required string Description { get; set; }

        public required decimal InitialBalance { get; set; }
    }
}
