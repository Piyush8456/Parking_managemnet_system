using Microsoft.AspNetCore.Mvc;

namespace Parking_Management_System.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
