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

        public List<Person> ParseVOListToEntityList(List<PersonVO> Persons)
        {
            if (Persons == null) return new List<Person>();
            return Persons.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> ParseEntityListToVOList(List<Person> Persons)
        {
            if (Persons == null) return new List<PersonVO>();
            return Persons.Select(item => Parse(item)).ToList();
        }
    }
}
