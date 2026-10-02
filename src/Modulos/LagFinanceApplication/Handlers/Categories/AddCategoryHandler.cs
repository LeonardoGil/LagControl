using LagBaseDomain;
using LagFinanceApplication.Commands.Categories;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Categories
{
    public class AddCategoryHandler(ICategoryRepository categoryRepository) : IRequestHandler<AddCategoryCommand>
    {
        public async Task<Unit> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var exists = await categoryRepository.Get().AnyAsync(x => x.Description == request.Description &&
                                                                      x.Type == request.Type, cancellationToken: cancellationToken);

            if (exists)
                throw DomainException.Create("Category with the same description and type already exists.");

            var category = new Category
            {
                Description = request.Description,
                Type = request.Type,
                ParentCategoryId = request.ParentCategoryId
            };

            categoryRepository.Add(category);
            categoryRepository.SaveChanges();

            return Unit.Value;
        }
    }
}

