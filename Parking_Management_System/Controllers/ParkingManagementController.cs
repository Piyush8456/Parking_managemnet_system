//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Parking_Management_System.Models;

//namespace Parking_Management_System.Controllers
//{
//    public class ParkingManagementController : Controller
//    {
//        ApplicationDbContext _dbContext;

//        public ParkingManagementController (ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        [HttpGet]
//        public IActionResult Registration()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Registration(VehicleRegistration registration)
//        {
//            _dbContext..Add(registration);
//            _dbContext.SaveChanges();

//            return RedirectToAction("Home");

//        }

//        //public IActionResult Home()
//        //{
//        //   var result = _dbContext.ToList();

//        //    return View(result);
//        //}
//    }
//}
