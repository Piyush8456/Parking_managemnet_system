using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management_System.Enum_s;
using Parking_Management_System.Models;
using System;

namespace Parking_Management_System.Controllers
{
    public class ParkingLotsController : Controller
    {
        ApplicationDbContext _DbContext;

        public ParkingLotsController(ApplicationDbContext context)
        {
            _DbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var parkingLot = await _DbContext.parkingLots.ToListAsync();

            return View(parkingLot);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var enumValues = Enum.GetValues(typeof(SpaceSize)).Cast<SpaceSize>().ToList();
            return View(enumValues);
        }

        [HttpPost]
        public IActionResult Create(ParkingLots parkingLots)
        {
            if (ModelState.IsValid) {
                _DbContext.parkingLots.Add(parkingLots);
                _DbContext.SaveChangesAsync();
            }
            return View(parkingLots);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var parkinhgLot = await _DbContext.parkingLots.FindAsync(id);

            return View(parkinhgLot);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var parkinhgLot = await _DbContext.parkingLots.FindAsync(id);

            return View(parkinhgLot);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ParkingLots parkingLot)
        {
            _DbContext.parkingLots.Update(parkingLot);
            await _DbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var parkingLot = await _DbContext.parkingLots.FirstOrDefaultAsync(pl => pl.Id == id);

            return View(parkingLot);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var parkingLot = _DbContext.parkingLots.FindAsync(id);
            await _DbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }


}

