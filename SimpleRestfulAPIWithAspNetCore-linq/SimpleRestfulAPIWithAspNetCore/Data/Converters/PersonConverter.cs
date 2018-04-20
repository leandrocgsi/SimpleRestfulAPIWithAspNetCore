using System.Collections.Generic;
using System.Linq;
using SimpleRestfulAPIWithAspNetCore.Data.Converter;
using SimpleRestfulAPIWithAspNetCore.Data.VO;
using SimpleRestfulAPIWithAspNetCore.Models.Entities;

namespace SimpleRestfulAPIWithAspNetCore.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public string FirstName { get; private set; }

        //Recebe um VO e retorna uma Entity
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return new Person();
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address
            };
        }

        //Recebe uma Entity e retorna um VO
        public PersonVO Parse(Person origin)
        {
            if (origin == null) return new PersonVO();
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address
            };
        }

        //Recebe uma lista de VO e retorna uma lista de Entities
        public List<Person> ParseList(List<PersonVO> Persons)
        {
            if (Persons == null) return new List<Person>();
            return Persons.Select(item => Parse(item)).ToList();
        }

        //Recebe uma lista de Entities e retorna uma lista de VO
        public List<PersonVO> ParseList(List<Person> Persons)
        {
            if (Persons == null) return new List<PersonVO>();
            return Persons.Select(item => Parse(item)).ToList();
        }

    }
}
