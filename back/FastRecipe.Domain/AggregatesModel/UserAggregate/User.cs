using FastRecipe.Domain.SeedWork;
using MongoDB.Bson;
using System;
using System.Text.Json.Serialization;

namespace FastRecipe.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity, IAggregateRoot
    {
        [JsonPropertyName("name")]
        public string Name { get; private set; }
        private DateTime RegDate { get; set; }

        public User() : base(ObjectId.GenerateNewId().ToString()) { }

        public User(string name) : this()
        {
            Name = ValidateName(name);
            RegDate = DateTime.Now;
        }

        private static string ValidateName(string name)
        {
            if (name.Length < 2) throw new ArgumentException("Name must be at least 2 characters long");

            return name;
        }
    }
}
