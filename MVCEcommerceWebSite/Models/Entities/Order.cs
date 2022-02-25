using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MVCEcommerceWebSite.Data
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string age { get; set; }
        [Required(ErrorMessage = "Please enter the address to ship to")]

        [ForeignKey("User")]
        public string UserId { get; set;  }
        // public OrderInfo OrderInfo { get; set; }

        public long AddressId { get; set; }
        public string TrackingNumber { get; set; }
        
        public DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }
        public virtual IdentityUser User { get; set; }
        

    }

}