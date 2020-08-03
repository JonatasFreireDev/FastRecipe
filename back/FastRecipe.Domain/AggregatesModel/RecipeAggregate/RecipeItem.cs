namespace FastRecipe.Domain.AggregatesModel.RecipeAggregate
{
    public class RecipeItem
    {
        public int Quantity { get; private set; }
        public string Name { get; private set; }

        public RecipeItem(int quantity, string name)
        {
            Quantity = quantity;
            Name = name;
        }
    }
}