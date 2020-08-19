using FastRecipe.Domain.SeedWork;
using System;

namespace FastRecipe.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public User(string name)
        {
            Name = ValidateName(name);
            RegistrationDate = DateTime.Now;
        }

        private static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2) throw new ArgumentException("Name must be at least 2 characters long");

            return name;
        }
    }
}
