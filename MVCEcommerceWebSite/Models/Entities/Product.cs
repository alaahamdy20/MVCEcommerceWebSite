using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using MVCEcommerceWebSite.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace MVCEcommerceWebSite.Data
{
    public class Product
    {
        
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        [ForeignKey("Category")]
        public long CategoryId { get; set; }
        [NotMapped] 
        public int CommentsCount { get; set; }
        //[ForeignKey("User")]
        //public string UserId { get; set; }
        public virtual ICollection<Colors> Colors { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual Category Category { get; set; }
        public virtual Collection<Comment> Comments { get; set; }
        //public virtual IdentityUser User { get; set; }


    }
}