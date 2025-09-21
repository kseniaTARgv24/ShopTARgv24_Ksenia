using System.ComponentModel.DataAnnotations;

namespace ShopTARgv24_Ksenia.Models.Kindergarten
{
    public class Kindergarten
    {
        public Guid? Guid { get; set; }
        public string? GroupName { get; set; }
        public int? ChildrenCount { get; set; }
        public string? KindergartenName { get; set; }
        public string? TeacherName { get; set; }
    }
}
