using FastRecipe.Domain.SeedWork;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FastRecipe.Domain.AggregatesModel.RecipeAggregate
{
    public class Recipe : Entity
    {
        private List<RecipeItem> _items;

        public string UserId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public List<RecipeItem> Items { get => ImmutableList<RecipeItem>.Empty.AddRange(_items).ToList(); private set => _items = value; }

        #region Constructors

        public Recipe(ObjectId id, string userId, string title, string description, DateTime regDate, List<RecipeItem> items)
            : base(id)
        {
            UserId = userId;
            Title = title;
            Description = description;
            _items = items;
            RegistrationDate = regDate;
        }

        public Recipe(string userId, string title, string description, List<RecipeItem> items)
            : this(ObjectId.GenerateNewId(), userId, title, description, DateTime.Now, items) { }

        #endregion Constructors

        public void AddRecipeItem(int qtd, string name)
        {
            var recipeItem = new RecipeItem(qtd, name);
            _items.Add(recipeItem);
        }
    }
}