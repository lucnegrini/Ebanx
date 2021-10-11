using Ebanx.Domain.Commands;

namespace Ebanx.Core.Interfaces
{
    public interface IAccountService
    {
        double GetBalanceFromAccount(int accountId);
        EventResponse PostEvent(EventRequest request);
    }
}
