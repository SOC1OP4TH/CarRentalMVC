using CarRentalMVC.Areas.Manage.Controllers;
using CarRentalMVC.DAL;
using CarRentalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarRentalMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

     
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

      


        public IActionResult Privacy()
        {
            return View();
        }
     


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> Index()
        {
            return _context.Cars != null ?
                        View(await _context.Cars.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Cars'  is null.");
        }

        // GET: Manage/Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

    }
}





// GET: Manage/Cars
