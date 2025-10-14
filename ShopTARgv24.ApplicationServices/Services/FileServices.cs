using ShopTARgv24_Ksenia.Core.Dto;
using ShopTARgv24_Ksenia.Data;
using Microsoft.Extensions.Hosting;
using ShopTARgv24_Ksenia.Core.Domain;
using ShopTARgv24_Ksenia.Core.ServiceInterface;

namespace ShopTARgv24_Ksenia.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly ShopContext _context;
        private readonly IHostEnvironment _webHost;

        public FileServices
            (
                ShopContext context,
                IHostEnvironment webHost
            )
        {
            _context = context;
            _webHost = webHost;
        }

        public void FilesToApi(SpaceshipDto dto, Spaceship spaceship)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\multipleFileUpload\\");
                }

                foreach (var file in dto.Files)
                {
                    //muutuja string uploadsFolder ja sinna laetakse failid
                    string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "multipleFileUpload");
                    //muutuja string uniqueFileName ja siin genereeritakse uus Guid ja lisatakse see faili ette
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.Name;
                    //muutuja string filePath kombineeritakse ja lisatakse koos kausta unikaalse nimega
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                        FileToApi path = new FileToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            SpaceshipId = spaceship.Id
                        };

                        _context.FileToApis.AddAsync(path);
                    }
                }
            }
        }

        //public void FilesToApiForKindergarten(Kindergarten kindergarten)
        //{
        //    throw new NotImplementedException();
        //}

        public void UploadFilesToDatabase(KindergartenDto dto, Kindergarten domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var file in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);

                        var fileToDb = new FileToDatabase
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = file.FileName,
                            ImageData = target.ToArray(),
                            KindergartenId = domain.Id
                        };

                        _context.FileToDatabases.Add(fileToDb);
                    }
                }
            }
        }


    }


}
