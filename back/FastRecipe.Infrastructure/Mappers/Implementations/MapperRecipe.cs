using System;
using System.Collections.Generic;
using System.Text;
using FastRecipe.Domain.AggregatesModel.RecipeAggregate;
using FastRecipe.Infrastructure.Mappers.Interfaces;

namespace FastRecipe.Infrastructure.Mappers.Implementations
{
    public class MapperRecipe : IMapper<RecipeDTO, Recipe>
    {
        public Recipe MapDTOToEntity(RecipeDTO dto)
        {
            throw new NotImplementedException();
        }

        public RecipeDTO MapEntityToDTO(Recipe dto)
        {
            throw new NotImplementedException();
        }
    }
}
