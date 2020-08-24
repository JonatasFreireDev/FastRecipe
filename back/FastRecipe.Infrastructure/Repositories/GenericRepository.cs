using FastRecipe.Domain.SeedWork;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastRecipe.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IAggregateRoot
    {
        private IMongoCollection<T> _collection { get; set; }

        public GenericRepository(IMongoDatabase database, string databaseName)
        {
            if (database == null) throw new ArgumentNullException(nameof(database), "Database were not informed");
            _collection = database.GetCollection<T>(databaseName);
        }

        public virtual async Task<bool> DeleteAsync(string id)
        {
            var parsedId = ObjectId.Parse(id);
            var result = await _collection.DeleteOneAsync(x => x._id == parsedId).ConfigureAwait(false);

            return result.IsAcknowledged;
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            var parsedId = ObjectId.Parse(id);
            var result = await _collection.FindAsync(x => x._id == parsedId, new FindOptions<T>
            {
                Limit = 1
            }).ConfigureAwait(false);

            return result.First();
        }

        public virtual Task<IEnumerable<T>> GetWithPagingAsync(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> InsertAsync(T obj)
        {
            return await _collection.InsertOneAsync(obj).ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    return true;
                else if (task.IsFaulted)
                    throw new TaskSchedulerException(task.Exception.Message, task.Exception);
                else
                    return false;
            }, TaskScheduler.Default).ConfigureAwait(false);
        }

        public virtual async Task<bool> UpdateAsync(string id, UpdateDefinition<T> update)
        {
            var parsedId = ObjectId.Parse(id);
            var result = await _collection.UpdateOneAsync(
                x => x._id == parsedId,
                update,
                new UpdateOptions { IsUpsert = false, BypassDocumentValidation = false }).ConfigureAwait(false);

            return result.IsAcknowledged;
        }
    }
}
