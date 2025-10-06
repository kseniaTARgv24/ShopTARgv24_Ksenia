﻿namespace ShopTARgv24_Ksenia.Models.RealEstate
{
    public class RealEstateImageViewModel
    {
        public Guid Id { get; set; }
        public string? ImageTitle { get; set; }
        public byte[]? ImageData { get; set; }
        public Guid? RealEstateId { get; set; }
    }
}
