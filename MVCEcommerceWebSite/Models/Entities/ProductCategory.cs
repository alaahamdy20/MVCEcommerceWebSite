using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Data
{
    public class ProductCategory
    {
        
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public Product Product { get; set; }
        
        [ForeignKey("Category")]
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}