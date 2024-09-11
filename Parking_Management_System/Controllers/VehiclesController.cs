using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management_System.Models;

namespace Parking_Management_System.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _DbContext;

        public VehiclesController(ApplicationDbContext context)
        {
            _DbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var Vehicles = await _DbContext.Vehicles.ToListAsync();
            return View(Vehicles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehicle vehicles)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Vehicles.Add(vehicles);
                await _DbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _DbContext.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }
            return View(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _DbContext.Vehicles.FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }
            return View(vehicles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _DbContext.Update(vehicle);
                    await _DbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (vehicle.Id <= 0)
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
            return View(vehicle);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _DbContext.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingSpace = await _DbContext.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            _DbContext.Vehicles.Remove(parkingSpace);
            await _DbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingSpaceExists(int id)
        {
            return _DbContext.parkingSpaces.Any(e => e.Id == id);
        }
    }
}
