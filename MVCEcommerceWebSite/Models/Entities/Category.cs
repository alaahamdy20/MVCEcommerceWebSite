using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCEcommerceWebSite.Data
{
    public class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        
        public virtual ICollection<CategoryImage> CategoryImages { get; set; }
        
    }
}