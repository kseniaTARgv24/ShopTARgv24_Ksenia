using System.ComponentModel.DataAnnotations;  //added???

namespace ShopTARgv24_Ksenia.Core.Domain
{
    public class Spaceship
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? TypeName { get; set; }
        public DateTime? BuiltDate { get; set; }
        public int? Crew { get; set; }
        public int? EnginePower { get; set; }
        public int? Passengers { get; set; }
        public int? InnerVolume { get; set; }
    }
}
