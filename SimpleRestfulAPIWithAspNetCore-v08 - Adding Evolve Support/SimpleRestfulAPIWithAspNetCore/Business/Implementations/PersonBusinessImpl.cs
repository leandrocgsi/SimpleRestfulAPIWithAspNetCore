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
            // Retorna uma nova instancia de PersonVO
            // O mais adequado é validar a entrada de dados
            if (person == null) return new PersonVO();

            // Converte um VO em uma entidade
            var personEntity = _converter.Parse(person);

            // Persiste os dados
            var result = _repository.Add(personEntity);

            // Converte a Entidade retornada em VO
            var personVO = _converter.Parse(result);

            //Retorna o VO
            return personVO;
        }

        public PersonVO FindById(long id)
        {
            // Converte a Entidade retornada em VO e a retorna
            return _converter.Parse(_repository.Find(id));
        }

        public List<PersonVO> FindAll()
        {
            //Busca todas as pessoas
            var persons = _repository.FindAll();

            // Converte a lista de Entidades retornada em VO e a retorna
            return _converter.ParseList(persons);
        }

        public PersonVO Update(PersonVO person)
        {
            // Retorna uma nova instancia de PersonVO
            // O mais adequado é validar a entrada de dados
            if (person == null) return new PersonVO();

            // Converte um VO em uma entidade
            var personEntity = _converter.Parse(person);

            // Atualiza os dados
            var result = _repository.Update(personEntity);

            // Converte a Entidade retornada em VO
            var personVO = _converter.Parse(result);

            //Retorna o VO
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
