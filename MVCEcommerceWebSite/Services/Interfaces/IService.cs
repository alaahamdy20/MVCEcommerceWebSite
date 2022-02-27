using MVCEcommerceWebSite.Data;
using System.Collections.Generic;

namespace MVCEcommerceWebSite.Services
{
    public interface IService<T>
    {

        
        int Add(T newObjectOfT);
        int Delete(long id);
        List<T> GetAll();
        T GetById(long id);
        T GetByName(string name);
        int Update(long id, T newObjectOfT);


    }
}
