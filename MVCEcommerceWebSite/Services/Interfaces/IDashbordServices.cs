using MVCEcommerceWebSite.Models.Entities;
using System.Collections.Generic;

namespace MVCEcommerceWebSite.Services
{
    public interface IDashbordServices
    {
        List<SellerUser> GetAll(string id);
    }
}