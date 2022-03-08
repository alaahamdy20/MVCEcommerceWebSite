using MVCEcommerceWebSite.Data;
using MVCEcommerceWebSite.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MVCEcommerceWebSite.Services
{
    public class DashbordServices : IDashbordServices
    {
        private readonly ApplicationDbContext dbContext;

        public DashbordServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<SellerUser> GetAll(string id)
        {
            return dbContext.SellerUsers.Where(s => s.userid == id).ToList();
        }
    }
}
