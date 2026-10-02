using LagFinanceApplication.Dtos.Categories;
using LagFinanceApplication.Queries.Categories;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Categories
{
    public class ListCategoriesHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryListQuery, IList<CategoryListDto>>
    {
        public async Task<IList<CategoryListDto>> Handle(CategoryListQuery query, CancellationToken cancellationToken)
        {
            var categories = categoryRepository.Get()
                                               .Where(x => !query.Type.HasValue || x.Type == query.Type.Value)
                                               .Include(x => x.ParentCategory)
                                               .Select(category => new CategoryListDto
                                               {
                                                   Id = category.Id,
                                                   Description = category.Description,
                                                   Type = category.Type,
                                                   ParentCategory = category.ParentCategory != null ? new CategoryListDto
                                                   {
                                                       Description = category.ParentCategory.Description,
                                                       Id = category.ParentCategory.Id,
                                                       Type = category.ParentCategory.Type
                                                   } : default
                                               })
                                               .OrderBy(x => x.Description);

            return await categories.ToListAsync(cancellationToken);
        }
    }
}

