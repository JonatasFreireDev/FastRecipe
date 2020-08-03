using FastRecipe.Domain.AggregatesModel.UserAggregate;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastRecipe.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IMongoCollection<User> _collection;

        public UserRepository(IMongoDatabase database)
        {
            if (database == null) throw new ArgumentNullException("Database were not defined");
            _collection = database.GetCollection<User>("Users");
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id).ConfigureAwait(false);

            return result.IsAcknowledged;
        }

        public User GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers(User obj)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(User user)
        {
            await _collection.InsertOneAsync(user).ConfigureAwait(false);
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
