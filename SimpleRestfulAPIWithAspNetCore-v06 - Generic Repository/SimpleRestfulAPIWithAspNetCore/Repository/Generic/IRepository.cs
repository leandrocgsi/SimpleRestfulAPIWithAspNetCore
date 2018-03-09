using SimpleRestfulAPIWithAspNetCore.Models.Entities.Base;
using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T item);
        T Update(T item);
        void Remove(object Id);
        void Remove(T item);
        IEnumerable<T> FindAll();
        T Find(object Id);
        bool Exists(object Id);

        List<T> FindWithPagedSearch(string query);
        List<T> FindWithPagedSearch(string query, object[] parameters);
        int GetCount(string query);
    }
}
