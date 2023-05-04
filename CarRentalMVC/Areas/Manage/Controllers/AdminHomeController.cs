using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cars()
        {
            return View();
        }
    }
}
