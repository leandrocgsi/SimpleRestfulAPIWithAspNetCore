using System.Collections.Generic;
using SimpleRestfulAPIWithAspNetCore.Models.Entities;
using SimpleRestfulAPIWithAspNetCore.Repository.Generic;
using SimpleRestfulAPIWithAspNetCore.Data.VO;
using SimpleRestfulAPIWithAspNetCore.Data.Converters;

namespace SimpleRestfulAPIWithAspNetCore.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        private IRepository<Person> _repository;
        
        //Declarando o nosso converter
        private readonly PersonConverter _converter;

        public PersonBusinessImpl(IRepository<Person> repository)
        {
            _repository = repository;

            //Instanciando o nosso converter
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            if (person == null) return new PersonVO();
            var personEntity = _converter.Parse(person);
            var result = _repository.Add(personEntity);
            var personVO = _converter.Parse(result);
            return personVO;
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.Find(id));
        }

        public List<PersonVO> FindAll()
        {
            var persons = _repository.FindAll();
            return _converter.ParseEntityListToVOList(persons);
        }

        public PersonVO Update(PersonVO person)
        {
            if (person == null) return new PersonVO();
            var personEntity = _converter.Parse(person);
            var result = _repository.Update(personEntity);
            var personVO = _converter.Parse(result);
            return personVO;
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
