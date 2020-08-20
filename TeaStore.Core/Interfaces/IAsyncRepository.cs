using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeaStore.Core.Entities;

namespace TeaStore.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        ValueTask<T> GetById(int id);

        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
