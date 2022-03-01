using MVCEcommerceWebSite.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Models.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Quantity { get; set; }

        [ForeignKey("Session")]
        public int SessionId { get; set; }

        [ForeignKey("Product")]
        public long ProductId { get; set; }


        public virtual ShoppingSession Session { get; set; }
        public virtual Product Product { get; set; }


    }
}
