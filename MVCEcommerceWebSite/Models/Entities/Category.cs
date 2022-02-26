using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Data
{
    public class Category
    {
        
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
        public string FilePath { get; set; }        
    }
}