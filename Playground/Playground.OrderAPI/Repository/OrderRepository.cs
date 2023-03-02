using Microsoft.EntityFrameworkCore;
using Playground.OrderAPI.Model;
using Playground.OrderAPI.Model.Context;

namespace Playground.OrderApi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<MySqlContext> _context;

        public OrderRepository(DbContextOptions<MySqlContext> context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeader header)
        {
            if (header == null) return false;
            await using var _db = new MySqlContext(_context);
            _db.Headers.Add(header);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task UpdateOrderPaymentStatus(long orderHeaderID, bool status)
        {
            await using var _db = new MySqlContext(_context);
            var header = await _db.Headers.FirstOrDefaultAsync(o=>o.Id== orderHeaderID);
            if(header != null)
            {
                header.PaymentStatus= status;
            }
        }
    }
}

