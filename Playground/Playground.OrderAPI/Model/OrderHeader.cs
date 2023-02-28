using Playground.OrderAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Playground.OrderAPI.Model
{
    [Table("Order_header")]
    public class OrderHeader : BaseEntity
    {
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("cupon_code")]
        public string CuponCode { get; set; }

        public string CuponCode { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateTime { get; set; }
        public string Phone { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpireMonthYear { get; set; }
        public int CartTotalItens { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
