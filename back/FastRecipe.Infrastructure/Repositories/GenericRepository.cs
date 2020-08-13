using FastRecipe.Domain.SeedWork;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastRecipe.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IAggregateRoot
    {
        private IMongoCollection<T> _collection;

        public GenericRepository(IMongoDatabase database)
        {
            if (database == null) throw new ArgumentNullException(nameof(database), "Database were not informed");
            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(x => x._id == id).ConfigureAwait(false);

            return result.IsAcknowledged;
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetWithPagingAsync(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(T obj)
        {
            return await _collection.InsertOneAsync(obj).ContinueWith((task) =>
            {
                return task.Status == TaskStatus.RanToCompletion;
            }, TaskScheduler.Default).ConfigureAwait(false);
        }

        public Task<bool> UpdateAsync(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
