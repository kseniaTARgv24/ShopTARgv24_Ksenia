using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public SpaceshipsController(ShopContext context, ISpaceshipsServices spaceshipsServices)
        {
            _context = context;
            _spaceshipsServices = spaceshipsServices;
        }

        // Index - вывод всех кораблей
        public IActionResult Index()
        {
            var spaceships = _context.Spaceships
                .Select(s => new SpaceshipsIndexViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    BuildDate = s.BuildDate,
                    TypeName = s.TypeName,
                    Crew = s.Crew
                })
                .ToList();

            return View(spaceships);
        }

        // Create - форма создания нового корабля
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new SpaceshipCreateUpdateVeiwModel();
            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateUpdateVeiwModel vm)
        {
            var dto = new SpaceshipDto
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
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _spaceshipsServices.Create(dto);
            return RedirectToAction(nameof(Index));
        }

        // Delete - подтверждение удаления
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _spaceshipsServices.DetailAsync(id);
            if (spaceship == null) return NotFound();

            var vm = new SpaceshipDeleteViewModel
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                TypeName = spaceship.TypeName,
                BuildDate = spaceship.BuildDate,
                Crew = spaceship.Crew,
                EnginePower = spaceship.EnginePower,
                Passengers = spaceship.Passengers,
                InnerVolume = spaceship.InnerVolume,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var deleted = await _spaceshipsServices.Delete(id);
            if (deleted == null) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        // Update - редактирование корабля
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship = await _spaceshipsServices.DetailAsync(id);
            if (spaceship == null) return NotFound();

            var vm = new SpaceshipCreateUpdateVeiwModel
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                TypeName = spaceship.TypeName,
                BuildDate = spaceship.BuildDate,
                Crew = spaceship.Crew,
                EnginePower = spaceship.EnginePower,
                Passengers = spaceship.Passengers,
                InnerVolume = spaceship.InnerVolume,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt
            };

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipCreateUpdateVeiwModel vm)
        {
            var dto = new SpaceshipDto
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
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _spaceshipsServices.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        // Details - просмотр информации о корабле
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var spaceship = await _spaceshipsServices.DetailAsync(id);
            if (spaceship == null) return NotFound();

            var vm = new SpaceshipDeleteViewModel
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                TypeName = spaceship.TypeName,
                BuildDate = spaceship.BuildDate,
                Crew = spaceship.Crew,
                EnginePower = spaceship.EnginePower,
                Passengers = spaceship.Passengers,
                InnerVolume = spaceship.InnerVolume,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt
            };

            return View(vm);
        }
    }
}
