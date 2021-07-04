using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Msys
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        bool Add(T entity);
        bool Update(Guid id, T entity);
        bool Delete(Guid? id, T entity);
        void SetDefaultData();
    }
}
