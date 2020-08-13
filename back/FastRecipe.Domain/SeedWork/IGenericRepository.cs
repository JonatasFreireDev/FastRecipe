﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastRecipe.Domain.SeedWork
{
    public interface IGenericRepository<T> where T : IAggregateRoot
    {
        Task<IEnumerable<T>> GetWithPagingAsync(int page, int itemsPerPage);
        Task<T> GetByIdAsync(string id);
        Task<bool> InsertAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(string id);
    }
}
