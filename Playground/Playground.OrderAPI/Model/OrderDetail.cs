using Playground.OrderAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Playground.OrderAPI.Model
{
    [Table("order_detail")]
    public class OrderDetail: BaseEntity
    {
        public long CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public virtual OrderHeader CartHeader { get; set; }

        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product{ get; set; }

        [Column("count")]
        public int Count { get; set; }

        public int Id { get; set; }
        public long CartHeaderId { get; set; }
        public CartHeaderVO CartHeader { get; set; }
        public long ProductId { get; set; }
        public ProductVO Product { get; set; }
        public int Count { get; set; }

    }
}
    