using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MVCEcommerceWebSite.Data;
using MVCEcommerceWebSite.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MVCEcommerceWebSite.Services
{
    
    public class ColorsService: IColorsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ColorsService(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            this.dbContext = dbContext;
            webHostEnvironment = hostEnvironment;

        }

        public int Add(Colors newObjectOfT)
        {
            dbContext.Add(newObjectOfT);
            return dbContext.SaveChanges();
        }

        public int Delete(long id)
        {
            dbContext.Remove(GetById(id));
            return dbContext.SaveChanges();
        }

        public List<Colors> GetAll()
        {
            return dbContext.Colors.ToList();
        }

        public Colors GetById(long id)
        {
             
            return dbContext.Colors.FirstOrDefault(p => p.Id == id);
        }

        public Colors GetByName(string name)
        {
            return dbContext.Colors.FirstOrDefault(p => p.Color == name);
        }

        public int Update(long id, Colors newObjectOfT)
        {
            Colors p =  GetById(id);
            p.Color = newObjectOfT.Color;
            
            return dbContext.SaveChanges();
        }
        

    }
}
