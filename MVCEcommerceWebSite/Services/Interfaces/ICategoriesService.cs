using MVCEcommerceWebSite.Data;
using System.Collections.Generic;

namespace MVCEcommerceWebSite.Services
{
    public interface ICategoriesService
    {

        
        int Add(Category newObjectOfCategory);
        int Delete(long id);
        List<Category> GetAll();
        Category GetById(long id);
        Category GetByName(string name);
        int Update(long id, Category newObjectOfCategory);


    }
}
