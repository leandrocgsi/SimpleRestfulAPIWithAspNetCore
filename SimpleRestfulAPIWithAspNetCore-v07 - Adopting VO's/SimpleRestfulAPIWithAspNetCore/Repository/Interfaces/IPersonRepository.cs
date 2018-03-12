using SimpleRestfulAPIWithAspNetCore.Models.Entities;
using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Repository.Interfaces
{
    public interface IPersonRepository
    {
        PersonVO Add(PersonVO person);
        PersonVO Update(PersonVO person);
        void Remove(long id);
        List<PersonVO> FindAll();
        PersonVO Find(long id);

        bool Exists(long id);
    }
}
