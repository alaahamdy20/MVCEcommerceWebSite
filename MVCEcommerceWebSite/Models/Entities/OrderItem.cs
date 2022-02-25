using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Data
{
    public class OrderItem
    {
        [Key]
        public long Id { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("Order")]
        public long OrderId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public virtual IdentityUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}