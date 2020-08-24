using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace FastRecipe.Domain.SeedWork
{
    public interface IAggregateRoot
    {
        public ObjectId _id { get; }
    }
}
