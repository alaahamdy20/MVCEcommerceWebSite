using MVCEcommerceWebSite.Data;
using MVCEcommerceWebSite.Models.Entities;
using System.Collections.Generic;

namespace MVCEcommerceWebSite.Services
{
    public interface IProductService
    {

        
        int Add(Product newObjectOfProduct);
        public int AddToSeller(SellerUser sellerUser);
        int Delete(long id);
        List<Product> GetAll();
        List<Product> GetProductsByColors(int[] Colors);
        List<Product> GetProductsByPrice(int min, int max);
        List<Product> GetProductsByCategory(int[] Categorys);
        
        Product GetById(long id);
        Product GetByName(string name);
        int Update(long id, Product newObjectOfProduct);


    }
}
