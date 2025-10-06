using ShopTARgv24_Ksenia.Core.Domain;
using ShopTARgv24_Ksenia.Core.Dto;

namespace ShopTARgv24_Ksenia.Core.ServiceInterface
{
    public interface IRealEstateServices
    {
        Task< RealEstate> Create( RealEstateDto dto);
        Task< RealEstate> DetailAsync(Guid id);
        Task< RealEstate> Delete(Guid id);
        Task< RealEstate> Update( RealEstateDto dto);
    }
}
