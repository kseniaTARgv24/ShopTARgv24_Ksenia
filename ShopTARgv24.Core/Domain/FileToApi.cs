namespace ShopTARgv24_Ksenia.Core.Domain
{
    public class FileToApi
    {
        public Guid Id { get; set; }

        // Путь к файлу
        public string? ExistingFilePath { get; set; }

        // Связь с кораблём (nullable)
        public Guid? SpaceshipId { get; set; }
        public Spaceship? Spaceship { get; set; }


        // Связь с детсадом (nullable)
        public Guid? KindergartenId { get; set; }
        public Kindergarten? Kindergarten { get; set; }

        // Дата добавления
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
