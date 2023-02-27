using Playground.CartAPI.Data.VO;
using Playground.CartAPI.Model;

namespace Playground.CartApi.Data.VO
{
    public class CartDetailVO
    {
        public long CartHeaderId { get; set; }
        public CartHeaderVO CartHeader { get; set; }
        public long ProductId { get; set; }
        public ProductVO Product { get; set; }
        public int Count { get; set; }
    }
}
