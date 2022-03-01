using MVCEcommerceWebSite.Data;
using MVCEcommerceWebSite.Models.Entities;
using System.Collections.Generic;

namespace MVCEcommerceWebSite.Services
{
    public interface IColorsService
    {

        
        int Add(Colors newObjectOfColors);
        int Delete(long id);
        List<Colors> GetAll();
        Colors GetById(long id);
        Colors GetByName(string name);
        int Update(long id, Colors newObjectOfColors);


    }
}
