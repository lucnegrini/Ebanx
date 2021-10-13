namespace Ebanx.Domain.Commands
{
    public class DepositResponse : IEventResponse
    {
        public AccountResponse destination { get; set; }
    }
}
