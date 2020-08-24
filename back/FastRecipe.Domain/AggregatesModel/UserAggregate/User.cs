using FastRecipe.Domain.SeedWork;
using MongoDB.Bson;
using System;

namespace FastRecipe.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        #region Constructors

        public User(ObjectId id, string name, DateTime regDate)
            : base(id)
        {
            Name = ValidateName(name);
            RegistrationDate = regDate;
        }

        public User(string name)
            : this(ObjectId.GenerateNewId(), name, DateTime.Now) { }

        #endregion

        private static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2) throw new ArgumentException("Name must be at least 2 characters long");

            return name;
        }
    }
}
