using Playground.OrderAPI.Model;

namespace Playground.OrderApi.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderPaymentStatus(long orderHeaderID, bool paid);

    }
}
