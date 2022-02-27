using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Data
{
    public class ProductImage : FileUpload
    {
        // Uploader
        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public virtual long ProductId { get; set; }
    }
}