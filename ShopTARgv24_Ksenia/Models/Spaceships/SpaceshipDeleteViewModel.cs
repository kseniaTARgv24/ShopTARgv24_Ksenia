using System.ComponentModel.DataAnnotations;

namespace ShopTARgv24_Ksenia.Models.Spaceships
{
    public class SpaceshipDeleteViewModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? TypeName { get; set; }
        public DateTime? BuildDate { get; set; }
        public int? Crew { get; set; }
        public int? EnginePower { get; set; }
        public int? Passengers { get; set; }
        public int? InnerVolume { get; set; }

        public List<ImageViewModel> ImageViewModels { get; set; }
            = new List<ImageViewModel>();

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
