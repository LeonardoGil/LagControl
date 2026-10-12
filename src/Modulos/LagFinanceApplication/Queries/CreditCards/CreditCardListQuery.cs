using System.Collections.Generic;
using LagFinanceApplication.Dtos.CreditCards;
using MediatR;

namespace LagFinanceApplication.Queries.CreditCards
{
    public class CreditCardListQuery : IRequest<IList<CreditCardListDto>>
    {
    }
}
