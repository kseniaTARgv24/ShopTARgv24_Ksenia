using Microsoft.AspNetCore.Http;

namespace ShopTARgv24_Ksenia.Core.Dto
{
    public class KindergartenDto
    {
        public Guid? Id { get; set; }
        public string? GroupName { get; set; }
        public int? ChildrenCount { get; set; }
        public string? KindergartenName { get; set; }
        public string? TeacherName { get; set; }


        //Tuleb teha muutuja Files ja see peab olema listis
        public List<IFormFile>? Files { get; set; }

        public IEnumerable<FileToDatabaseDto> Image { get; set; }
            = new List<FileToDatabaseDto>();

        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
