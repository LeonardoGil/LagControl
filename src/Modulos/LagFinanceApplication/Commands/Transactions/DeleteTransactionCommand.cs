using MediatR;

namespace LagFinanceApplication.Commands.Transactions
{
    public class DeleteTransactionCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}

