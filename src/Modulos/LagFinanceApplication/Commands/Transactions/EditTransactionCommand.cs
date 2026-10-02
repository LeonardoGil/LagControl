using MediatR;

namespace LagFinanceApplication.Commands.Transactions
{
    public class EditTransactionCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public string? Description { get; set; }

        public string? Notes { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? Date { get; set; }

        public bool? Pending { get; set; }

        public Guid? AccountId { get; set; }

        public Guid? CategoryId { get; set; }
    }
}

