using CarRentalMVC.Abstraction;
using CarRentalMVC.DAL;
using CarRentalMVC.Models;
using CarRentalMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CarsController : Controller
    {
        private readonly AppDbContext _context;
        IBaseRepository<Car> _db;

        public CarsController(AppDbContext context, IBaseRepository<Car> db)
        {
            _context = context;
            _db = db;
        }

        // GET: Manage/Cars
        public IActionResult Index()
        {
            //return _context.Cars != null ? 
            //            View(await _context.Cars.ToListAsync()) :
            //            Problem("Entity set 'AppDbContext.Cars'  is null.");

            return View(_db.GetList());
        }

        // GET: Manage/Cars/Details/5
        public IActionResult Details(int id)
        {

            var car = _db.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Manage/Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("id,brand,model,year,color,number,price,isActive")] Car car)
        {
            if (ModelState.IsValid)
            {
                _db.Create(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Manage/Cars/Edit/5
        public IActionResult Edit(int id)
        {

            var car = _db.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("id,brand,model,year,color,number,price,isActive")] Car car)
        {
            if (id != car.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var res = _db.Get(id);
                if (res != null)
                {
                    try
                    {
                        _db.Update(res);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CarExists(car.id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Manage/Cars/Delete/5
        public IActionResult Delete(int id)
        {
            
            if (CarExists(id) == null)
            {
                return NotFound();
            }
            _db.Delete(id);

            return View(nameof(Index));
        }

        // POST: Manage/Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'AppDbContext.Cars'  is null.");
            }
            var car =_db.Get(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _db.GetList().Any(x => x.id == id);
        }
    }
}
