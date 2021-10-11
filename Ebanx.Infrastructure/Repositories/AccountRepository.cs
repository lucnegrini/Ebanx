using Ebanx.Domain;
using Ebanx.Infrastructure.Abstractions;
using Ebanx.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ebanx.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private static IList<Account> Accounts;
        public AccountRepository()
        {
            Accounts = new List<Account>();
        }

        public Account GetAccountById(int accountId)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == accountId);

            if (account == null)
                throw new InvalidAccountException();

            return account;
        }
    }
}
