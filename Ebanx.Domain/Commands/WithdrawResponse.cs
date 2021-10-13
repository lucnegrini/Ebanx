namespace Ebanx.Domain.Commands
{
    public class WithdrawResponse : IEventResponse
    {
        public AccountResponse origin { get; set; }
    }
}
