using MVCEcommerceWebSite.Data;
using System.Collections.Generic;

namespace MVCEcommerceWebSite.Services
{
    public interface IService<T>
    {

        
        int Add(T newObjectOfT);
        int Delete(int id);
        List<T> GetAll();
        T GetById(int id);
        T GetByName(string name);
        int Update(int id, T newObjectOfT);


    }
}
