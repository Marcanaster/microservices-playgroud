namespace Playground.OrderAPI.Messages
{
    public class CartDetailVO
    {
        public int Id { get; set; }
        public long CartHeaderId { get; set; }
        public long ProductId { get; set; }
        public virtual ProductVO Product { get; set; }
        public int Count { get; set; }
    }
}
