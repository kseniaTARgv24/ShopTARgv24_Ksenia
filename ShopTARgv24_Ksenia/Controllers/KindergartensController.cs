using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARgv24_Ksenia.ApplicationServices.Services;
using ShopTARgv24_Ksenia.Core.Domain;
using ShopTARgv24_Ksenia.Core.ServiceInterface;
using ShopTARgv24_Ksenia.Data;

namespace ShopTARgv24_Ksenia.Controllers
{
    public class KindergartensController : Controller
    {
        private readonly ShopContext _context;
        private readonly IFileServices _fileServices;

        public KindergartensController(ShopContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }

        // GET: Kindergartens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kindergartens.ToListAsync());
        }

        // GET: Kindergartens/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindergarten = await _context.Kindergartens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kindergarten == null)
            {
                return NotFound();
            }

            return View(kindergarten);
        }

        // GET: Kindergartens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kindergartens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Kindergarten dto)
        {
            if (ModelState.IsValid)
            {
                var kindergarten = new Kindergarten
                {
                    Id = Guid.NewGuid(),
                    GroupName = dto.GroupName,
                    ChildrenCount = dto.ChildrenCount,
                    KindergartenName = dto.KindergartenName,
                    TeacherName = dto.TeacherName,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };

                _context.Add(kindergarten);
                await _context.SaveChangesAsync();

                _fileServices.UploadFilesToDatabase(dto, kindergarten);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: Kindergartens/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindergarten = await _context.Kindergartens.FindAsync(id);
            if (kindergarten == null)
            {
                return NotFound();
            }
            return View(kindergarten);
        }

        // POST: Kindergartens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Id,GroupName,ChildrenCount,KindergartenName,TeacherName,CreateAt,UpdateAt")] Kindergarten kindergarten)
        {
            if (id != kindergarten.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kindergarten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KindergartenExists(kindergarten.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kindergarten);
        }

        // GET: Kindergartens/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindergarten = await _context.Kindergartens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kindergarten == null)
            {
                return NotFound();
            }

            return View(kindergarten);
        }

        // POST: Kindergartens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var kindergarten = await _context.Kindergartens.FindAsync(id);
            if (kindergarten != null)
            {
                _context.Kindergartens.Remove(kindergarten);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KindergartenExists(Guid? id)
        {
            return _context.Kindergartens.Any(e => e.Id == id);
        }
    }
}
