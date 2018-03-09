using System.Collections.Generic;
using SimpleRestfulAPIWithAspNetCore.Models.Entities;
using SimpleRestfulAPIWithAspNetCore.Repository.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        //Declarando o repositório
        private IRepository<Person> _repository;

        public PersonBusinessImpl(IRepository<Person> repository)
        {
            //Atribuindo o repositório injetado
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Add(person);
        }

        public Person FindById(long id)
        {
            return _repository.Find(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Remove(id);
        }

        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }
    }
}
