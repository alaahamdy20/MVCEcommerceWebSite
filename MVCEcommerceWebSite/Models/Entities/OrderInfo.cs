
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerceWebSite.Data
{
    public class OrderInfo
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Address")]
        public long AddressId { get; set; }
        public Address Address { get; set; }
        public string TrackingNumber { get; set; }
/*        public ShippingStatus ShippingStatus { get; set; }
*/    }
}