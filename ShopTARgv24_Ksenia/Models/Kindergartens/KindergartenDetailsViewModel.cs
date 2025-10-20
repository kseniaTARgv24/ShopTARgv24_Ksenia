using System.ComponentModel.DataAnnotations;
using ShopTARgv24_Ksenia.Core.Domain;

namespace ShopTARgv24_Ksenia.Models.Kindergartens
{
    public class KindergartenDetailsViewModel
    {
        public Guid? Id { get; set; }
        public string? GroupName { get; set; }
        public int? ChildrenCount { get; set; }
        public string? KindergartenName { get; set; }
        public string? TeacherName { get; set; }
        public List<IFormFile>? Files { get; set; }
        public List<KindergartenImageViewModel> Image { get; set; }
    = new List<KindergartenImageViewModel>();
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }


    }
}
