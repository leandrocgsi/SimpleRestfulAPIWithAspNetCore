using SimpleRestfulAPIWithAspNetCore.Data.Converter;
using SimpleRestfulAPIWithAspNetCore.Data.VO;
using SimpleRestfulAPIWithAspNetCore.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SimpleRestfulAPIWithAspNetCore.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            throw new System.NotImplementedException();
        }

        public PersonVO Parse(Person origin)
        {
            throw new System.NotImplementedException();
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
