using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.Entity;
using Demo.Models;
using Demo.Repo;

namespace Demo.Controllers
{
    public class CarDetailsController : Controller
    {
        private readonly CarDetailsDbContext _context;
        private readonly IrepoCar _repo;

        public CarDetailsController(CarDetailsDbContext context,IrepoCar repo)
        {
            _context = context;
            _repo=repo;
        }   

        // GET: CarDetails
        public async Task<IActionResult> Index()
        {
            return View(_repo.index());
        }

        // GET: CarDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cardetails == null)
            {
                return NotFound();
            }

            var carDetails = _repo.details(id);
            if (carDetails == null)
            {
                return NotFound();
            }

            return View(carDetails);
        }

        // GET: CarDetails/Create
        public IActionResult Create()
        {

            List<SelectListItem> listOfBrand = new()
            {
                new SelectListItem { Value = "0", Text = "Audi" },
                new SelectListItem { Value = "1", Text = "Maruti" },
                new SelectListItem { Value = "2", Text = "BMW" },
            };
            List<SelectListItem> listOfModel = new()
            {
                new SelectListItem { Value = "0", Text = "X2010" },
                new SelectListItem { Value = "1", Text = "X2015" },
            };
            List<SelectListItem> listOfnewCar = new()
            {
                new SelectListItem { Value = "0", Text = "Yes" },
                new SelectListItem { Value = "1", Text = "No" },
            };

            ViewBag.listofBrand = listOfBrand;
            ViewBag.listofModel = listOfModel;
            ViewBag.listofnewCar = listOfnewCar;

            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,brand,modal,carName,Price,newcar")] CarDetails carDetails)
        {
            if (ModelState.IsValid)
            {
                var createCar= _repo.create(carDetails);
                return RedirectToAction(nameof(Index));
            }
            return View(carDetails);
        }

        // GET: CarDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            List<SelectListItem> listOfBrand = new()
            {
                new SelectListItem { Value = "0", Text = "Audi" },
                new SelectListItem { Value = "1", Text = "Maruti" },
                new SelectListItem { Value = "2", Text = "BMW" },
            };
            List<SelectListItem> listOfModel = new()
            {
                new SelectListItem { Value = "0", Text = "X2010" },
                new SelectListItem { Value = "1", Text = "X2015" },
            };
            List<SelectListItem> listOfnewCar = new()
            {
                new SelectListItem { Value = "0", Text = "Yes" },
                new SelectListItem { Value = "1", Text = "No" },
            };

            ViewBag.listofBrand = listOfBrand;
            ViewBag.listofModel = listOfModel;
            ViewBag.listofnewCar = listOfnewCar;

            if (id == null || _context.cardetails == null)
            {
                return NotFound();
            }

            var carDetails = _repo.edit(id);
            if (carDetails == null)
            {
                return NotFound();
            }
            return View(carDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,brand,modal,carName,Price,newcar")] CarDetails carDetails)
        {
            if (id != carDetails.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.editConfirm(carDetails);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarDetailsExists(carDetails.id))
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
            return View(carDetails);
        }

        // GET: CarDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cardetails == null)
            {
                return NotFound();
            }

            var carDetails = _repo.delete(id);
            if (carDetails == null)
            {
                return NotFound();
            }

            return View(carDetails);
        }

        // POST: CarDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cardetails == null)
            {
                return Problem("Entity set 'CarDetailsDbContext.cardetails'  is null.");
            }
            var carDetails = _repo.deleteConfirm(id);
            if (carDetails != null)
            {
                _context.cardetails.Remove(carDetails);
            }
            
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CarDetailsExists(int id)
        {
          return _context.cardetails.Any(e => e.id == id);
        }
    }
}
