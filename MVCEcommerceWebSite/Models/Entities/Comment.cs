using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Data
{
    public class Comment
    {
        public Comment()
        {
            //CreatedAt = DateTime.Now;
        }
        [Key]
        public long Id { get; set; }
        public string Content { get; set; }
        public int? Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        // public Rating Rating { get; set; }
        public long RatingId { get; set; }

        public string RenderContent()
        {
            throw new NotImplementedException();
        }

        public virtual Product Product { get; set; }
        public virtual HashSet<Comment> Replies { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}