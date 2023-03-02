using Playground.CartAPI.Data.VO;

namespace Playground.CartApi.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> getCouponByCouponCode(string code, string token);
    }
}
