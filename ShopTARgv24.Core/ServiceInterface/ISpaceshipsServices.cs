using ShopTARgv24_Ksenia.Core.Domain;
using ShopTARgv24_Ksenia.Core.Dto;

namespace ShopTARgv24_Ksenia.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Create(SpaceshipDto dto);
        Task<Spaceship> DetailAsync(Guid id);
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
    }
}
