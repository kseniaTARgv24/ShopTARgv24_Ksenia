namespace ShopTARgv24_Ksenia.Core.Domain
{
    public class FileToApi
    {
        public Guid Id { get; set; }

        public string ExistingFilePath { get; set; }

        // связь с Spaceship
        public Guid SpaceshipId { get; set; }
        public Spaceship Spaceship { get; set; }
    }
}
