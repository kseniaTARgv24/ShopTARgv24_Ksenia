﻿using System.ComponentModel.DataAnnotations;

namespace ShopTARgv24_Ksenia.Models.Kindergartens
{
    public class KindergartenCreateUpdateVeiwModel
    {
        public Guid? Id { get; set; }
        public string? GroupName { get; set; }
        public int? ChildrenCount { get; set; }
        public string? KindergartenName { get; set; }
        public string? TeacherName { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
