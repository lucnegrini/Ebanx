using Ebanx.Domain;

namespace Ebanx.Infrastructure.Abstractions
{
    public interface IAccountRepository
    {
        Account GetAccountById(int accountId);
    }
}
