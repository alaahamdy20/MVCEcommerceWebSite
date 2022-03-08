using Microsoft.AspNetCore.Identity;
using MVCEcommerceWebSite.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Models.Entities
{
    public class SellerUser
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public string userid { set; get; }
        [Key, Column(Order = 1)]
        [ForeignKey("product")]
        public long productid { set; get; }
        public virtual Product product { set; get; }
        public virtual IdentityUser User { get; set; }
    }
}
