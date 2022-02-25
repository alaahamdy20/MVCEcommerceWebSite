using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCEcommerceWebSite.Data
{
    public class Tag
    {
        public Tag()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        [Key]
        [Required] public long Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<TagImage> TagImages { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}