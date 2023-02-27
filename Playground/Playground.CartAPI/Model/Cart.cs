using Playground.CartAPI.Model.Base;

namespace Playground.CartApi.Model
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartDetail> CartDetails { get; set; }
    }
}
