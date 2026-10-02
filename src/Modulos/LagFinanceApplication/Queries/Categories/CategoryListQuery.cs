using System.Collections.Generic;
using LagFinanceApplication.Dtos.Categories;
using LagFinanceDomain.Enums;
using MediatR;

namespace LagFinanceApplication.Queries.Categories
{
    public class CategoryListQuery : IRequest<IList<CategoryListDto>>
    {
        public CategoryTypeEnum? Type { get; set; }
    }
}

