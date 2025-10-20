using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARgv24_Ksenia.Core.Dto;
using ShopTARgv24_Ksenia.Core.ServiceInterface;
using ShopTARgv24_Ksenia.Data;
using ShopTARgv24_Ksenia.Models.Kindergartens;
using ShopTARgv24_Ksenia.Models.Spaceships;

namespace ShopTARgv24_Ksenia.Controllers
{
    public class KindergartensController : Controller
    {
        private readonly ShopContext _context;
        private readonly IKindergartensServices _kindergartenServices;
        private readonly IFileServices _fileServices;

        public KindergartensController
            (
                ShopContext context,
                IKindergartensServices kindergartenServices,
                IFileServices fileServices

            )
        {
            _context = context;
            _kindergartenServices = kindergartenServices;
            _fileServices = fileServices;
        }

        public IActionResult Index()
        {
            var result = _context.Kindergartens
                .Select(x => new Models.Kindergartens.KindergartensIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                    TeacherName = x.TeacherName,
                    KindergartenName = x.KindergartenName
                });

            return View(result);
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";

            KindergartenCreateUpdateViewModel result = new();

            return View("CreateUpdate", result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName,
                CreateAt = vm.CreateAt,
                UpdateAt = vm.UpdateAt,
                Files = vm.Files,
                Image = vm.Image
                    .Select(x =>
                    {
                        Guid kindergartenId = (Guid)x.KindergartenId;
                        return new FileToDatabaseDto
                        {
                            Id = x.ImageId,
                            ImageData = x.ImageData,
                            ImageTitle = x.ImageTitle,
                            KindergartenId = kindergartenId,
                        };
                    }).ToArray()
            };
            var result = await _kindergartenServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        //Update
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            KindergartenImageViewModel[] images = await FilesFromDatabase(id);

            var vm = new KindergartenCreateUpdateViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.TeacherName = kindergarten.TeacherName;
            vm.CreateAt = kindergarten.CreateAt;
            vm.UpdateAt = kindergarten.UpdateAt;
            vm.Image.AddRange(images);

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName,
                CreateAt = vm.CreateAt,
                UpdateAt = vm.UpdateAt,
                Files = vm.Files,
                Image = vm.Image
                    .Select(x => new FileToDatabaseDto
                    {
                        Id = x.ImageId,
                        ImageData = x.ImageData,
                        ImageTitle = x.ImageTitle,
                        KindergartenId = (Guid)x.KindergartenId
                    }).ToArray()
            };

            var result = await _kindergartenServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            KindergartenImageViewModel[] images = await FilesFromDatabase(id);

            var vm = new KindergartenDeleteViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.TeacherName = kindergarten.TeacherName;
            vm.CreateAt = kindergarten.CreateAt;
            vm.UpdateAt = kindergarten.UpdateAt;
            vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kindergarten = await _kindergartenServices.Delete(id);
            if (kindergarten != null)
                return RedirectToAction(nameof(Index));

            return NotFound();
        }

        // Details
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            KindergartenImageViewModel[] images = await FilesFromDatabase(id);

            var vm = new Models.Kindergartens.KindergartenDetailsViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.TeacherName = kindergarten.TeacherName;
            vm.CreateAt = kindergarten.CreateAt;
            vm.UpdateAt = kindergarten.UpdateAt;
            vm.Image.AddRange(images);

            return View(vm);
        }

        // Meetod piltide toomiseks andmebaasist
        public async Task<KindergartenImageViewModel[]> FilesFromDatabase(Guid id)
        {
            var images = await _context.FileToDatabase
                .Where(x => x.KindergartenId == id)
                .Select(y => new KindergartenImageViewModel
                {
                    KindergartenId = y.KindergartenId,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64, {0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            return images;
        }

        // Meetod ühe pilte eemaldamiseks andmebaasist
        [HttpPost]
        public async Task<IActionResult> RemoveImage(KindergartenImageViewModel vm)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = vm.ImageId
            };

            var image = await _fileServices.RemoveImageFromDatabase(dto);

            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
