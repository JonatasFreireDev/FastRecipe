using FastRecipe.Domain.SeedWork;

namespace FastRecipe.Infrastructure.Mappers.Interfaces
{
    public interface IMapper<TDataObject, TEntityObject>
        where TDataObject : class
        where TEntityObject : Entity
    {
        TEntityObject MapDTOToEntity(TDataObject dto);

        TDataObject MapEntityToDTO(TEntityObject entity);
    }
}
