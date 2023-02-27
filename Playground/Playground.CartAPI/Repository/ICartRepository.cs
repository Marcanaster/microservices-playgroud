using Playground.CartApi.Data.VO;

namespace Playground.CartApi.Repository
{
    public interface ICartRepository
    {
        Task<CartVO> FindCartByUserID(string userId);
        Task<CartVO> SaveOrUpdateCart(CartVO cart);
        Task<bool> RemoveFromCart(long cartDetailId);
        Task<bool> ApplyCupon(string userId, string ciponCode);
        Task<bool> RemoveCupon(string userId);
        Task<bool> ClearCard(string userID);

    }
}
