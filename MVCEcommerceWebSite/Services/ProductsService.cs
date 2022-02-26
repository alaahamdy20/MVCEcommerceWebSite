using Microsoft.AspNetCore.Hosting;
using MVCEcommerceWebSite.Data;
using System.Collections.Generic;
using System.Linq;

namespace MVCEcommerceWebSite.Services
{
    
    public class ProductsService:IService<Product>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsService(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            this.dbContext = dbContext;
            webHostEnvironment = hostEnvironment;

        }

        public int Add(Product newObjectOfT)
        {
            dbContext.Add(newObjectOfT);
            return dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            dbContext.Remove(GetById(id));
            return dbContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return dbContext.Products.ToList();
        }

        public Product GetById(int id)
        {
             
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product GetByName(string name)
        {
            return dbContext.Products.FirstOrDefault(p => p.Name == name);
        }

        public int Update(int id, Product newObjectOfT)
        {
            Product p =  GetById(id);
            p.Name = newObjectOfT.Name;
            p.Price = newObjectOfT.Price;
            p.Description = newObjectOfT.Description;
            p.Stock = newObjectOfT.Stock;
            p.ProductImages = newObjectOfT.ProductImages;
            return dbContext.SaveChanges();
        }
        
    }
}
