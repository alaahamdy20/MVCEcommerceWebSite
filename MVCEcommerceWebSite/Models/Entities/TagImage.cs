using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Data
{
    public class TagImage : FileUpload
    {
        [ForeignKey("Tag")]
        public long TagId { get; set; }
        public virtual Tag Tag { get; set; }
        
    }
}