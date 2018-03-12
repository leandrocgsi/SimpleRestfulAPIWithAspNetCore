using System.Collections.Generic;
using SimpleRestfulAPIWithAspNetCore.Models.Entities;
using SimpleRestfulAPIWithAspNetCore.Repository.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        //Declarando o repositório
        private IRepository<PersonVO> _repository;

        public PersonBusinessImpl(IRepository<PersonVO> repository)
        {
            //Atribuindo o repositório injetado
            _repository = repository;
        }

        public PersonVO Create(PersonVO person)
        {
            return _repository.Add(person);
        }

        public PersonVO FindById(long id)
        {
            return _repository.Find(id);
        }

        public List<PersonVO> FindAll()
        {
            return _repository.FindAll();
        }

        public PersonVO Update(PersonVO person)
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
