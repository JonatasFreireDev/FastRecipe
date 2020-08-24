using FastRecipe.Domain.AggregatesModel.UserAggregate;
using FastRecipe.Infrastructure.Mappers.Interfaces;

namespace FastRecipe.Infrastructure.Mappers.Implementations
{
    public class MapperUser : IMapper<UserDTO, User>
    {
        public User MapDTOToEntity(UserDTO dto)
        {
            return new User(dto.Name);
        }

        public UserDTO MapEntityToDTO(User entity)
        {
            return new UserDTO
            {
                Id = entity._id.ToString(),
                Name = entity.Name,
                RegistrationDate = entity.RegistrationDate
            };
        }
    }
}
