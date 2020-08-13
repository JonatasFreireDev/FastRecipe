using FastRecipe.Domain.AggregatesModel.UserAggregate;
using FastRecipe.Infrastructure.Mappers.Interfaces;
using System;

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
                Name = entity.Name,
                RegistrationDate = entity.RegistrationDate
            };
        }
    }
}
