using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARgv24_Ksenia.Core.Dto;
using ShopTARgv24_Ksenia.Core.ServiceInterface;
using ShopTARgv24_Ksenia.Data;
using ShopTARgv24_Ksenia.Models.Spaceships;


namespace ShopTARgv24_Ksenia.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopContext _context;
        private readonly ISpaceshipsServices _spaceshipsServices;
        private readonly IFileServices _fileServices;

        public SpaceshipsController(ShopContext context, ISpaceshipsServices spaceshipsServices)
        {
            _context = context;
            _spaceshipsServices = spaceshipsServices;
        }

        // Index - вывод всех кораблей
        public IActionResult Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaceshipsIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    BuildDate = x.BuildDate,
                    TypeName = x.TypeName,
                    Crew = x.Crew,
                });


            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            SpaceshipCreateUpdateViewModel result = new();
            return View("CreateUpdate", result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                TypeName = vm.TypeName,
                BuildDate = vm.BuildDate,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower,
                Passengers = vm.Passengers,
                InnerVolume = vm.InnerVolume,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                FileToApiDtos = vm.Image
                    .Select(x => new FileToApiDto
                    {
                        Id = x.ImageId,
                        ExistingFilePath = x.FilePath,
                        SpaceshipId = x.SpaceshipId
                    }).ToArray()
            };

            var result = await _spaceshipsServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _spaceshipsServices.DetailAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.SpaceshipId == id)
                .Select(y => new ImageViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id,
                }).ToArrayAsync();

            var vm = new SpaceshipDeleteViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.TypeName = spaceship.TypeName;
            vm.BuildDate = spaceship.BuildDate;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.Passengers = spaceship.Passengers;
            vm.InnerVolume = spaceship.InnerVolume;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;
            vm.ImageViewModels.AddRange(images);


            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {

            var deleted = await _spaceshipsServices.Delete(id);

            if (deleted == null)
            {
                return NotFound();
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var update = await _spaceshipsServices.DetailAsync(id);

            if (update == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.SpaceshipId == id)
                .Select(y => new ImageViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id,
                }).ToArrayAsync();

            var vm = new SpaceshipCreateUpdateViewModel();

            vm.Id = update.Id;
            vm.Name = update.Name;
            vm.TypeName = update.TypeName;
            vm.BuildDate = update.BuildDate;
            vm.Crew = update.Crew;
            vm.EnginePower = update.EnginePower;
            vm.Passengers = update.Passengers;
            vm.InnerVolume = update.InnerVolume;
            vm.CreatedAt = update.CreatedAt;
            vm.ModifiedAt = update.ModifiedAt;
            vm.Image.AddRange(images);


            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                TypeName = vm.TypeName,
                BuildDate = vm.BuildDate,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower,
                Passengers = vm.Passengers,
                InnerVolume = vm.InnerVolume,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                FileToApiDtos = vm.Image
                    .Select(x => new FileToApiDto
                    {
                        Id = x.ImageId,
                        ExistingFilePath = x.FilePath,
                        SpaceshipId = x.SpaceshipId
                    }).ToArray()

            };

            var result = await _spaceshipsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var spaceship = await _spaceshipsServices.DetailAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.SpaceshipId == id)
                .Select(y => new ImageViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id,
                }).ToArrayAsync();

            var vm = new SpaceshipDetailsViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.TypeName = spaceship.TypeName;
            vm.BuildDate = spaceship.BuildDate;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.Passengers = spaceship.Passengers;
            vm.InnerVolume = spaceship.InnerVolume;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;
            vm.Image.AddRange(images);

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(ImageViewModel vm)
        {
            //peate läbi viewModeli edastama Id dto -sse
            //tuleb esile kustuda removeImageFromAppi meetod
            //kui image on null, siis returib Index vaatele

            // 1) Собираем dto из viewModel
            var dto = new FileToApiDto()
            {
                Id = vm.ImageId,
                // SpaceshipId = vm.SpaceshipId,
                // ExistingFilePath = vm.FilePath
            };

            // 2) Вызываем сервис удаления
            var image = await _fileServices.RemoveImageFromApi(dto);

            // 3) Если картинка не найдена → возврат к списку
            if (image == null)
                return RedirectToAction(nameof(Index));

            // 4) Если удалена успешно → тоже возврат к списку
            return RedirectToAction(nameof(Index));
        }
    }
}
