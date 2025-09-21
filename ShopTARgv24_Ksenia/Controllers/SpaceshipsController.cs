using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopTARgv24_Ksenia.Data;
using ShopTARgv24_Ksenia.Models;
using ShopTARgv24_Ksenia.Models.Spaceships;

namespace ShopTARgv24_Ksenia.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopContext _context;

        public SpaceshipsController(ShopContext context)
        {
            _context = context;
        }

        // GET: Spaceships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spaceship.ToListAsync());
        }

        // GET: Spaceships/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaceship = await _context.Spaceship
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spaceship == null)
            {
                return NotFound();
            }

            return View(spaceship);
        }

        // GET: Spaceships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spaceships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TypeName,BuiltDate,Crew,EnginePower,Passengers,InnerVolume")] Spaceship spaceship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spaceship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spaceship);
        }

        // GET: Spaceships/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaceship = await _context.Spaceship.FindAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }
            return View(spaceship);
        }

        // POST: Spaceships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Id,Name,TypeName,BuiltDate,Crew,EnginePower,Passengers,InnerVolume")] Spaceship spaceship)
        {
            if (id != spaceship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spaceship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpaceshipExists(spaceship.Id))
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
            return View(spaceship);
        }

        // GET: Spaceships/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaceship = await _context.Spaceship
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spaceship == null)
            {
                return NotFound();
            }

            return View(spaceship);
        }

        // POST: Spaceships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var spaceship = await _context.Spaceship.FindAsync(id);
            if (spaceship != null)
            {
                _context.Spaceship.Remove(spaceship);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpaceshipExists(Guid? id)
        {
            return _context.Spaceship.Any(e => e.Id == id);
        }
    }
}
