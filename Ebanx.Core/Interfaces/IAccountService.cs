using Ebanx.Domain.Commands;

namespace Ebanx.Core.Interfaces
{
    public interface IAccountService
    {
        double GetBalanceFromAccount(string accountId);
        IEventResponse PostEvent(EventRequest request);
        void ResetState();
    }
}
