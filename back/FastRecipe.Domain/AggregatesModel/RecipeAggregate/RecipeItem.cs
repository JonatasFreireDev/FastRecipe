using FastRecipe.Domain.SeedWork;
using System.Collections.Generic;

namespace FastRecipe.Domain.AggregatesModel.RecipeAggregate
{
    public class RecipeItem : ValueObject
    {
        public int Quantity { get; private set; }
        public string Name { get; private set; }

        public RecipeItem(int quantity, string name)
        {
            Quantity = quantity;
            Name = name;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Quantity;
            yield return Name;
        }
    }
}