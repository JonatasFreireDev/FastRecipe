using FastRecipe.Domain.AggregatesModel.UserAggregate;
using MongoDB.Driver;

namespace FastRecipe.Infrastructure.Repositories
{
    public class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(IMongoDatabase database) : base(database, "Users")
        {
        }
    }
}
