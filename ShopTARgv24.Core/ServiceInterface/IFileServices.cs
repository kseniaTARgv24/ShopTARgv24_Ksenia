using ShopTARgv24_Ksenia.Core.Domain;
using ShopTARgv24_Ksenia.Core.Dto;

namespace ShopTARgv24_Ksenia.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship spaceship);
        Task<FileToApi?> RemoveImageFromApi(FileToApiDto dto);
        Task<List<FileToApi>> RemoveImagesFromAppi(FileToApiDto[] dtos);
    }
}
