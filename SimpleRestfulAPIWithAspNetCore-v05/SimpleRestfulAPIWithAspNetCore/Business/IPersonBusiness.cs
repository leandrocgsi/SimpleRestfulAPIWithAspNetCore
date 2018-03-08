using SimpleRestfulAPIWithAspNetCore.Models;
using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(string personId);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(string personId);
    }
}
