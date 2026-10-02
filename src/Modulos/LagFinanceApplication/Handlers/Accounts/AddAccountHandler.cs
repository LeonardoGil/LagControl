using LagBaseDomain;
using LagFinanceApplication.Commands.Accounts;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Accounts
{
    public class AddAccountHandler(IAccountRepository accountRepository) : IRequestHandler<AddAccountCommand>
    {
        public async Task<Unit> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var exists = await accountRepository.Get().AnyAsync(x => x.Description == request.Description, cancellationToken: cancellationToken);

            if (exists)
                throw DomainException.Create("Account with the same description already exists.");

            var account = new Account
            {
                Description = request.Description
            };

            accountRepository.Add(account);
            accountRepository.SaveChanges();

            if (request.InitialBalance > 0)
            {
                // Cadastrar Transação inicial
                // Problema: Definir qual categoria será informado...
                
                throw new NotImplementedException();
            }

            return Unit.Value;
        }
    }
}
