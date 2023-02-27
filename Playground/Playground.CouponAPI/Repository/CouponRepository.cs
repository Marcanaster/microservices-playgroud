using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playground.CouponAPI.Data.VO;
using Playground.CouponAPI.Model.Context;

namespace Playground.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public CouponRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponVO> getCouponByCouponCode(string code)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync( c => c.CouponCode == code);
            return _mapper.Map<CouponVO>(coupon);
        }
    }
}
