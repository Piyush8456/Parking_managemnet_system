using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management_System.Models;

namespace Parking_Management_System.Controllers
{
    public class ParkingSpacesController : Controller
    {
        private readonly ApplicationDbContext _DbContext;

        public ParkingSpacesController(ApplicationDbContext context)
        {
            _DbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var parkingSpaces = await _DbContext.parkingSpaces.ToListAsync();
            return View(parkingSpaces);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParkingSpace parkingSpace)
        {
            if (ModelState.IsValid)
            {
                _DbContext.parkingSpaces.Add(parkingSpace);
                await _DbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingSpace);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpace = await _DbContext.parkingSpaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingSpace == null)
            {
                return NotFound();
            }
            return View(parkingSpace);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpace = await _DbContext.parkingSpaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingSpace == null)
            {
                return NotFound();
            }
            return View(parkingSpace);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ParkingSpace parkingSpace)
        {
            if (id != parkingSpace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _DbContext.Update(parkingSpace);
                    await _DbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingSpaceExists(parkingSpace.Id))
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
            return View(parkingSpace);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpace = await _DbContext.parkingSpaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingSpace == null)
            {
                return NotFound();
            }
            return View(parkingSpace);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingSpace = await _DbContext.parkingSpaces
                .FirstOrDefaultAsync(m => m.Id == id);
            _DbContext.parkingSpaces.Remove(parkingSpace);
            await _DbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingSpaceExists(int id)
        {
            return _DbContext.parkingSpaces.Any(e => e.Id == id);
        }
    }
}