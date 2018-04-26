using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRestfulAPIWithAspNetCore.Models.Entities.Base;
using SimpleRestfulAPIWithAspNetCore.Models.Entities.Context;

namespace SimpleRestfulAPIWithAspNetCore.Repository.Generic
{
    // A implementação do repositório genérico
    // Recebe qualquer Tipo T que implemente IRepository de mesmo tipo
    // Desde que T extenda BaseEntity
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;

        // Declaração de um dataset genérico
        private DbSet<T> dataSet;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }

        public T Add(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Update(T item)
        {
            var result = dataSet.SingleOrDefault(i => i.Id == item.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public void Remove(object id)
        {
            T result = dataSet.SingleOrDefault(i => i.Id.Equals(id));
            try
            {
                dataSet.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(T entityToDelete)
        {
            try
            { 
                if (_context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dataSet.Attach(entityToDelete);
                }
                dataSet.Remove(entityToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T Find(object id)
        {
            return dataSet.SingleOrDefault(m => m.Id.Equals(id));
        }

        public bool Exists(object Id)
        {
            return dataSet.Any(b => b.Id.Equals(Id));
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return dataSet.FromSql<T>(query).ToList();
        }

        public List<T> FindWithPagedSearch(string query, object[] parameters)
        {
            return dataSet.FromSql<T>(query, parameters).ToList();
        }

        public int GetCount(string query)
        {
            return dataSet.FromSql(query).Count();
        }
    }
}