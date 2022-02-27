using MVCEcommerceWebSite.Data;
using System.Collections.Generic;

namespace MVCEcommerceWebSite.Models.Entities
{
    public class Colors
    {
        public int Id { get; set; }
        public string Color { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }

    }
}
