using MongoDB.Bson;

namespace FastRecipe.Domain.SeedWork
{
    public interface IAggregateRoot
    {
        public ObjectId _id { get; }
    }
}
