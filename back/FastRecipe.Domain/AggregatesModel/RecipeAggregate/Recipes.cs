using FastRecipe.Domain.SeedWork;
using MongoDB.Bson;
using System.Collections.Generic;
using System.IO;

namespace FastRecipe.Domain.AggregatesModel.RecipeAggregate
{
    public class Recipes : Entity
    {
        private readonly List<RecipeItem> _items;

        public string UserId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyCollection<RecipeItem> Items => _items;

        #region Constructors

        public Recipes(string userId, string title, string description, List<RecipeItem> items)
        {
            UserId = userId;
            Title = title;
            Description = description;
            _items = items;
        }

        #endregion

        public void AddRecipeItem(int qtd, string name)
        {
            var recipeItem = new RecipeItem(qtd, name);
            _items.Add(recipeItem);
        }
    }
}