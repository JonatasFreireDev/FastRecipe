using System;
using System.Collections.Generic;
using System.Text;

namespace FastRecipe.Domain.AggregatesModel.RecipeAggregate
{
    public class RecipeDTO
    {
        public string Title { get; set; }

        public string? Id { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public List<RecipeItem> Items { get; set; }
    }
}
