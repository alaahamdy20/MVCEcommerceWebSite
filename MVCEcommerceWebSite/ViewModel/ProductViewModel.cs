using MVCEcommerceWebSite.Data;
using System.Collections.Generic;

namespace MVCEcommerceWebSite.ViewModel
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<ProductImage> product_Images { get; set; }


    }
}
