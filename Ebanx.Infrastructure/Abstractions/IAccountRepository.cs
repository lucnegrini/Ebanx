using Ebanx.Domain;
using Ebanx.Domain.Commands;

namespace Ebanx.Infrastructure.Abstractions
{
    public interface IAccountRepository
    {
        Account GetAccountById(string accountId);
        double Deposit(string accountId, double amount);
        double Withdraw(string accountId, double amount);
        void Reset();
    }
}
