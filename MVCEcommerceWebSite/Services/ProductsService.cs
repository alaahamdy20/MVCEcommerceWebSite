using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MVCEcommerceWebSite.Data;
using MVCEcommerceWebSite.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MVCEcommerceWebSite.Services
{
    
    public class ProductsService:IProductService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsService(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            this.dbContext = dbContext;
            webHostEnvironment = hostEnvironment;

        }

        public int Add(Product newObjectOfProduct)
        {
            dbContext.Add(newObjectOfProduct);
            return dbContext.SaveChanges();
        }
        public int AddToSeller(SellerUser sellerUser)
        {
            dbContext.SellerUsers.Add(sellerUser);
            return dbContext.SaveChanges();
        }

        public int Delete(long id)
        {
            dbContext.Remove(GetById(id));
            return dbContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return dbContext.Products.ToList();
        }

        public Product GetById(long id)
        {
             
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product GetByName(string name)
        {
            return dbContext.Products.FirstOrDefault(p => p.Name == name);
        }

        public int Update(long id, Product newObjectOfT)
        {
            Product p =  GetById(id);
            p.Name = newObjectOfT.Name;
            p.Price = newObjectOfT.Price;
            p.Description = newObjectOfT.Description;
            p.Stock = newObjectOfT.Stock;
            p.ProductImages = newObjectOfT.ProductImages;
            return dbContext.SaveChanges();
        }

        public List<Product> GetProductsByColors(int[] colors)
        {
            List<Product> products = new List<Product>();
            foreach (var item in colors)
            {
                products.AddRange(dbContext.Colors.FirstOrDefault(c => c.Id == item).Products);
            }

            return products;
        }
        public List<Product> GetProductsByPrice(int min, int max)
        {
            return dbContext.Products.Where(p=>p.Price >= min && p.Price <= max).ToList();
        }

        public List<Product> GetProductsByCategory(int[] Categorys)
        {
            List<Product> products = new List<Product>();
            foreach (var item in Categorys)
            {
                products.AddRange(dbContext.Categories.FirstOrDefault(c => c.Id == item).Products);
            }

            return products;
        }
    }
}
