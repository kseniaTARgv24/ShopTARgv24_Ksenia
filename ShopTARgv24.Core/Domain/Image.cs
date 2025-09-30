using System.ComponentModel.DataAnnotations;  //added???

namespace ShopTARgv24_Ksenia.Core.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string FilePath { get; set; } = null!;

        public Guid SpaceshipId { get; set; }
        public Spaceship Spaceship { get; set; } = null!;
    }

}
