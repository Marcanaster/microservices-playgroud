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

        [Column("purchase_amount")]
        public decimal PurchaseAmount { get; set; }

        [Column("discount_amount")]
        public decimal DiscountAmount { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("purchase_date")]
        public DateTime DateTime { get; set; } 
        
        [Column("order_time")]
        public DateTime OrderTime { get; set; }

        [Column("phone_number")]
        public string Phone { get; set; }

        [Column("card_number")]
        public string? CardNumber { get; set; }

        [Column("cvv")]
        public string? CVV { get; set; }

        [Column("expire_month_year")]
        public string? ExpireMonthYear { get; set; }

        [Column("total_itens")]
        public int CartTotalItens { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        [Column("payment_status")]
        public bool PaymentStatus { get; set; }
    }
}
