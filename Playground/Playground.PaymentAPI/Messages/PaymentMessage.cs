using Playground.MessageBus;

namespace Playground.PaymentAPI.Messages
{
    public class PaymentMessage : BaseMessage
    {
        public long OrderId { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpireMonthYear { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string Email { get; set; }

    }
}
