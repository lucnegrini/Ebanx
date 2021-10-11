using Ebanx.Core.Interfaces;
using Ebanx.Domain.Commands;
using Ebanx.Infrastructure.Abstractions;

namespace Ebanx.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public double GetBalanceFromAccount(int accountId)
        {
            var account = _accountRepository.GetAccountById(accountId);

            return account.Balance;
        }

        public EventResponse PostEvent(EventRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
