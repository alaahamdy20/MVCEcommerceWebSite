using System;
using System.ComponentModel.DataAnnotations;

namespace MVCEcommerceWebSite.Data
{
    public interface ITimeStampedModel
    {
        [Key]
        long Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}