using SimpleRestfulAPIWithAspNetCore.Models.Entities;
using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Person Add(Person person);
        Person Update(Person person);
        void Remove(long id);
        List<Person> FindAll();
        Person Find(long id);

        bool Exists(long id);
    }
}
