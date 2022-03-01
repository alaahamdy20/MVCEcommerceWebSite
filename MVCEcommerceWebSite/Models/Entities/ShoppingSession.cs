using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Models.Entities
{
    public class ShoppingSession
    {

        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public decimal Total { get; set; }

        public virtual IdentityUser User { get; set; }

    }
}
