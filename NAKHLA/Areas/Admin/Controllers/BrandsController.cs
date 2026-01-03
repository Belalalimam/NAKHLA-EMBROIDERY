using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAKHLA.DataAccess;

namespace NAKHLA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrandsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Title = "Brand Management";
            ViewBag.PageTitle = "Brands";
            ViewBag.Subtitle = "Manage product brands";

            var brands = _context.Brands.Include(e => e.Products).OrderByDescending(e => e.Status).AsQueryable();

            // Add Filters
            if (!brands.Any())
            {
                // No data in database
                ViewBag.Message = "No brands found. Add some brands first.";
            }

            var totalHodsOfPage = Math.Ceiling(brands.Count() / 8.0);
            var currentPage = page;
            ViewBag.totalHodsOfPage = totalHodsOfPage;
            ViewBag.currentPage = currentPage;

            brands = brands.Skip((page - 1) * 8).Take(8);

            return View(brands.ToList());



        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Brand brand)
        {
            Console.WriteLine($"ModelState IsValid: {ModelState.IsValid}");

            // Log all validation errors
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Error: {error.ErrorMessage}");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Brands.Add(brand);
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = $"Brand '{brand.Name}' created successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    ModelState.AddModelError("", $"Error saving brand: {ex.Message}");
                }
            }

            return View(brand);
        }




        //[HttpGet]
        //public IActionResult Edit()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Edit()
        //{
        //    return View();
        //}

        //[HttpGet]
        //[HttpPost]




    }
}
