namespace Ebanx.Domain.Commands
{
    public class TransferResponse : IEventResponse
    {
        public AccountResponse origin { get; set; }
        public AccountResponse destination { get; set; }
    }
}
