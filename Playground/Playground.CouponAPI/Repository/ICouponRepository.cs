using Playground.CouponAPI.Data.VO;

namespace Playground.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> getCouponByCouponCode(string code);
    }
}
