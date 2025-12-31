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
            return View(new Brand());
        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (!ModelState.IsValid)
                return View(brand);

            _context.Add(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
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
