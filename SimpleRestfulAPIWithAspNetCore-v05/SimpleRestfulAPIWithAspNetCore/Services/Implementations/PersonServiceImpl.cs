using System.Collections.Generic;
using System;
using SimpleRestfulAPIWithAspNetCore.Models;
using SimpleRestfulAPIWithAspNetCore.Models.Context;
using System.Linq;
using SimpleRestfulAPIWithAspNetCore.Repository.Interfaces;

namespace SimpleRestfulAPIWithAspNetCore.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {

        private readonly IPersonRepository _repository;

        public PersonServiceImpl(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        // Método responsável por retornar uma pessoa
        public Person FindById(string id)
        {
            return _repository.FindById(id);
        }

        // Método responsável por retornar todas as pessoas
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }
    }
}
