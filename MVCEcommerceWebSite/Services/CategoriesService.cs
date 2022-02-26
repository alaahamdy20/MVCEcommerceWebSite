using MVCEcommerceWebSite.Data;
using System.Collections.Generic;
using System.Linq;

namespace MVCEcommerceWebSite.Services
{
    public class CategoriesService : IService<Category>
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(Category newObjectOfT)
        {
            dbContext.Add(newObjectOfT);
            return dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            dbContext.Remove(GetById(id));
            return dbContext.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {

            return dbContext.Categories.FirstOrDefault(p => p.Id == id);
        }

        public Category GetByName(string name)
        {
            return dbContext.Categories.FirstOrDefault(p => p.Name == name);
        }

        public int Update(int id, Category newObjectOfT)
        {
            Category p = GetById(id);
            p.Name = newObjectOfT.Name;
            p.CategoryImages = newObjectOfT.CategoryImages;
            
            return dbContext.SaveChanges();
        }
    }
}