using System.Collections.Generic;
using SimpleRestfulAPIWithAspNetCore.Models.Entities;
using SimpleRestfulAPIWithAspNetCore.Repository.Interfaces;
using SimpleRestfulAPIWithAspNetCore.Models.Entities.Context;
using System;
using System.Linq;

namespace SimpleRestfulAPIWithAspNetCore.Repository.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MySQLContext _context;

        public PersonRepository(MySQLContext context)
        {
            _context = context;
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public PersonVO Add(PersonVO person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        // Método responsável por retornar uma pessoa
        public PersonVO Find(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        // Método responsável por retornar todas as pessoas
        public List<PersonVO> FindAll()
        {
            return _context.Persons.ToList();
        }

        // Método responsável por atualizar uma pessoa
        public PersonVO Update(PersonVO person)
        {
            // Verificamos se a pessoa existe na base
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exists(person.Id)) return new PersonVO();

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = _context.Persons.SingleOrDefault(b => b.Id == person.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void Remove(long id)
        {
            var result = _context.Persons.SingleOrDefault(i => i.Id.Equals(id));
            try
            {
                if (result != null) _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(b => b.Id.Equals(id));
        }
    }
}
