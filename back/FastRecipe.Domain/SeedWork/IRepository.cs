using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastRecipe.Domain.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IEnumerable<T> GetUsers(T obj);
        T GetById(string id);
        Task InsertAsync(T obj);
        void Update(T obj);
        Task<bool> DeleteAsync(string id);
    }
}
