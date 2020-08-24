using FastRecipe.Domain.AggregatesModel.RecipeAggregate;
using FastRecipe.Infrastructure.Mappers.Interfaces;
using System;

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
