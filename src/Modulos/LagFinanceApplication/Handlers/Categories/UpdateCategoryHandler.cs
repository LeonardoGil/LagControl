using LagFinanceApplication.Commands.Categories;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Categories
{
    public class UpdateCategoryHandler(ICategoryRepository categoryRepository) : IRequestHandler<UpdateCategoryCommand>
    {
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.Get().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                          ?? throw new KeyNotFoundException("Category not found");

            category.Description = request.Description;
            category.Type = request.Type;
            category.ParentCategoryId = request.ParentCategoryId;

            categoryRepository.Update(category);
            categoryRepository.SaveChanges();

            return Unit.Value;
        }
    }
}
