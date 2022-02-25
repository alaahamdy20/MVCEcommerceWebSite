using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Data
{
    public class UserImage
    {
        [ForeignKey("User")]
        public string UserId;
        public virtual IdentityUser User { get; set; }
    }
}