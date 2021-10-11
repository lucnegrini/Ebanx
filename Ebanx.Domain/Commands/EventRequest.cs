using Ebanx.Domain.Enums;

namespace Ebanx.Domain.Commands
{
    public class EventRequest
    {
        public EventTypeEnum type { get; set; }
        public string destination { get; set; }
        public string origin { get; set; }
        public double amount { get; set; }
    }
}
