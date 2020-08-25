using FastRecipe.Domain.AggregatesModel.RecipeAggregate;
using FastRecipe.Infrastructure.Mappers.Interfaces;
using System;

namespace FastRecipe.Infrastructure.Mappers.Implementations
{
    public class MapperRecipe : IMapper<RecipeDTO, Recipe>
    {
        public Recipe MapDTOToEntity(RecipeDTO dto)
        {
            return new Recipe(dto.UserId, dto.Title, dto.Description, dto.Items);
        }

        public RecipeDTO MapEntityToDTO(Recipe entity)
        {
            return new RecipeDTO
            {
                Description = entity.Description,
                Id = entity._id.ToString(),
                Items = entity.Items,
                RegistrationDate = entity.RegistrationDate,
                Title = entity.Title,
                UserId = entity.UserId
            };
        }
    }
}
