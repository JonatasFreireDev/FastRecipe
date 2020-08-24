using FastRecipe.Domain.AggregatesModel.RecipeAggregate;
using MongoDB.Driver;

namespace FastRecipe.Infrastructure.Repositories
{
    public class RecipeRepository : GenericRepository<Recipe>
    {
        public RecipeRepository(IMongoDatabase database) : base(database, "Recipes")
        {
        }
    }
}
