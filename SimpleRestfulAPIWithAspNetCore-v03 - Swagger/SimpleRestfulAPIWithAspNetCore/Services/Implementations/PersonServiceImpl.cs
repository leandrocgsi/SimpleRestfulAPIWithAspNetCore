﻿using System;
using System.Collections.Generic;
using SimpleRestfulAPIWithAspNetCore.Models;
using System.Threading;

namespace SimpleRestfulAPIWithAspNetCore.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        // Contador responsável por gerar um fake ID já que não estamos
        // acessando nenhum banco de dados
        private volatile int count;

        // Metodo responsável por criar uma nova pessoa
        // Se tivéssemos um banco de dados esse seria o
        // momento de persistir os dados
        public Person Create(Person person)
        {
            return person;
        }

        // Método responsável por retornar uma pessoa
        // como não acessamos nenhuma base de dados
        // estamos retornando um mock
        public Person FindById(string personId)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Leandro",
                LastName = "Costa",
                Address = "Uberlândia - Minas Gerais - Brasil"
            };
        }

        // Método responsável por retornar todas as pessoas
        // mais uma vez essas informações são mocks
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        // Método responsável por atualizar uma pessoa
        // por ser mock retornamos a mesma informação passada
        public Person Update(Person person)
        {
            return person;
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void Delete(string personId)
        {
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
