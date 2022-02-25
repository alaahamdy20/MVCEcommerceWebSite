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
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [Required(ErrorMessage = "Please enter the address to ship to")]

        public virtual IdentityUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        // public OrderInfo OrderInfo { get; set; }

        public virtual Address Address { get; set; }
        [ForeignKey("Address")]
        public long AddressId { get; set; }
        public string TrackingNumber { get; set; }
/*        public ShippingStatus OrderStatus { get; set; }
*/        [NotMapped] public decimal Sum { get; set; }

        public DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }


    }

}