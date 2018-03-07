using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using SimpleRestfulAPIWithAspNetCore.Models;
using System.Threading;
using SimpleRestfulAPIWithAspNetCore.Models.Context;
using System.Linq;

namespace SimpleRestfulAPIWithAspNetCore.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        // Contador responsável por gerar um fake ID já que não estamos
        // acessando nenhum banco de dados
        private volatile int count;

        private readonly MySQLContext _context;

        public PersonServiceImpl(MySQLContext context)
        {
            _context = context;
        }

        // Metodo responsável por criar uma nova pessoa
        // Se tivéssemos um banco de dados esse seria o
        // momento de persistir os dados
        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        // Método responsável por retornar uma pessoa
        // como não acessamos nenhuma base de dados
        // estamos retornando um mock
        public Person FindById(string id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        // Método responsável por retornar todas as pessoas
        // mais uma vez essas informações são mocks
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        // Método responsável por atualizar uma pessoa
        // por ser mock retornamos a mesma informação passada
        public Person Update(Person person)
        {
            var returnPerson = new Person();
            //var result = _context.Exists(person.Id);
            //if (!result) return new Person();
            var updated = _context.Persons.Update(person);
            return person;
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void Delete(string id)
        {
            var result = _context.Persons.SingleOrDefault(i => i.Id.Equals(id));
            _context.Persons.Remove(result);
            _context.SaveChanges();
            //A nossa lógica de exclusão viria aqui
        }

        // Método responsável por mockar uma pessoa
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Last Name " + i,
                Address = "Some Address in Brasil " + i
            };
        }
        
        public Int32 IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
