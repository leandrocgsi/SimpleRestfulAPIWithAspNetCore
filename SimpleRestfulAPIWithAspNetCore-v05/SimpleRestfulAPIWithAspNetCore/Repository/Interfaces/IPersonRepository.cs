using SimpleRestfulAPIWithAspNetCore.Models;
using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Repository.Interfaces
{
    interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(string id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(string id);

        bool Exists(long id);
    }
}
