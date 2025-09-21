using System.ComponentModel.DataAnnotations;  //added???

namespace ShopTARgv24_Ksenia.Core.Domain
{
    public class Kindergarten
    {

       public Guid? Guid { get; set; }
       public string? GroupName { get; set; }
       public int? ChildrenCount { get; set; }
       public string? KindergartenName { get; set; }
       public string? TeacherName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
