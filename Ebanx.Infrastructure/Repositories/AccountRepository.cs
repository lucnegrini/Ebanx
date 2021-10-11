using Ebanx.Domain;
using Ebanx.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

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
            throw new NotImplementedException();
        }
    }
}
