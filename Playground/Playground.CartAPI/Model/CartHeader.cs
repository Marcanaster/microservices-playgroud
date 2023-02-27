using Playground.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Playground.CartApi.Model
{
    [Table("Cart_header")]
    public class CartHeader : BaseEntity
    {
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("cupon_code")]
        public string CuponCode { get; set; }
    }
}
