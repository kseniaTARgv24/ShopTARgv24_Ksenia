using System.ComponentModel.DataAnnotations;
using ShopTARgv24_Ksenia.Models.RealEstate;


namespace ShopTARgv24_Ksenia.Models.Spaceships
{
    public class RealEstateCreateUpdateViewModel
    {
        public Guid Id { get; set; }

        public double? Area { get; set; }
        public string Location { get; set; }
        public int? RoomNumber { get; set; }
        public string? BuildingType { get; set; }

        public List<IFormFile> Files { get; set; }
        public List <RealEstateImageViewModel>Image { get; set; } 
                    = new List<RealEstateImageViewModel>();
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
