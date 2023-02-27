using Playground.Web.Models;

namespace Playground.Web.Services.IService
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetCoupon(string code, string token);
        
    }
}
