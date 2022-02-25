using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Data
{
    public class ProductTag
    {
        [Column(Order = 0)]
        [Key]
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Tag")]
        [Column(Order = 1)]
        [Key]
        public long TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}