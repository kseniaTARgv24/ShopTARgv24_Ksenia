﻿namespace ShopTARgv24_Ksenia.Core.Dto
{
    public class FileToApiDto
    {
        public Guid Id { get; set; }
        public string? ExistingFilePath { get; set; }
        public Guid? SpaceshipId { get; set; }
        public Guid? KindergartenId { get; set; }
    }
}
