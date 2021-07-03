using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Msys
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        void Add(T entity);
        void Update(Guid id, T entity);
        bool Delete(Guid? id, T entity);
        void SetDefaultData();
    }
}
