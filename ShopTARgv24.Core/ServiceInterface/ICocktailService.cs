
using ShopTARgv24_Ksenia.Core.Dto;

namespace ShopTARgv24_Ksenia.Core.ServiceInterface
{
    public interface ICocktailService
    {
        Task<CocktailSearchResultDto?> SearchByNameAsync(string name);
        Task<DrinkDto?> GetByIdAsync(string id);
    }
}
