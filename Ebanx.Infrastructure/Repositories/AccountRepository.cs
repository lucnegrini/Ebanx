using Ebanx.Domain;
using Ebanx.Infrastructure.Abstractions;
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

        public double Deposit(string accountId, double amount)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == accountId);
            account ??= new Account(accountId);

            account.Balance += amount;

            Accounts.Remove(account);
            Accounts.Add(account);

            return account.Balance;
        }

        public Account GetAccountById(string accountId)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == accountId);

            if (account == null)
                throw new Exception("Can't find account");

            return account;
        }

        public void Reset()
        {
            Accounts = new List<Account>();
            return;
        }

        public double Withdraw(string accountId, double amount)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == accountId);

            if (account == null)
                throw new Exception("Can't find account");

            account.Balance -= amount;

            //Accounts.Remove(account);
            //Accounts.Add(account);

            return account.Balance;
        }
    }
}
