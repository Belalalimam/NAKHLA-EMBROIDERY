using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAKHLA.DataAccess;
using NAKHLA.ViewModels;

namespace NAKHLA.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(FilterVM filterVM, int page = 1)
        {
            const int discount = 50;
            var products = _context.Products.AsQueryable();

            // Filter
            if (filterVM.Name is not null)
            {
                products = products.Where(e => e.Name.Contains(filterVM.Name));
                ViewBag.ProductName = filterVM.Name;
            }

            if (filterVM.MinPrice is not null)
            {
                products = products;
                ViewBag.MinPrice = filterVM.MinPrice;
            }

            if (filterVM.MaxPrice is not null)
            {
                products = products;
                ViewBag.MaxPrice = filterVM.MaxPrice;
            }

            if (filterVM.CategoryId is not null)
            {
                products = products.Where(e => e.CategoryId == filterVM.CategoryId);
                ViewBag.CategoryId = filterVM.CategoryId;
            }

            if (filterVM.IsHot)
            {
                products = products.Where(e => e.Discount >= discount);
                ViewBag.isHot = filterVM.IsHot;
            }


            // Categories
            var categories = _context.Categorise;
            ViewData["categories"] = categories.ToList();
            ViewBag.categories = categories.ToList();

            // Paginitation
            var totalNumberOfPages = Math.Ceiling(products.Count() / 8.0);
            var currentPage = page;
            ViewBag.totalNumberOfPages = totalNumberOfPages;
            ViewBag.currentPage = currentPage;

            products = products.Skip((page - 1) * 10).Take(10);


            return View(products.ToList());
        }


        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(e => e.Category).FirstOrDefault(e => e.Id == id);

            if (product is null)
                return RedirectToAction(nameof(NotFoundPage));

            product.Traffic += 1;
            _context.SaveChanges();

            var relatedProducts = _context.Products.Include(e => e.Category).Where(e => e.CategoryId == product.CategoryId && e.Id != product.Id).Skip(0).Take(4);

            var topProducts = _context.Products.Include(e => e.Category).Where(e => e.Id != product.Id).OrderByDescending(e => e.Traffic).Skip(0).Take(4);

            var similarProducts = _context.Products.Include(e => e.Category).Where(e => e.Name.Contains(product.Name) && e.Id != product.Id).Skip(0).Take(4);

            //var MinMaxPriceProducts = _context.Products.Include(e => e.Category).Where(e=>e.Price >= product.Price * 0.9 && e.Price <= product.Price * 1.1 && e.Id != product.Id).Skip(0).Take(4);

            return View(new ProductWithRelatedVM()
            {
                Product = product,
                RelatedProducts = relatedProducts.ToList(),
                TopProducts = topProducts.ToList(),
                SimilarProducts = similarProducts.ToList()
            });

        }


        public IActionResult NotFoundPage()
        {
            return View();
        }






        public ViewResult PersonalInfo()
        {
            string name = "Mohamed";
            int age = 27;
            string address = "Mansoura";
            char gender = 'M';

            List<string> skills = new List<string>
        {
            "C", "C++", "C#", "SQL Server"
        };

            var PersonalInfoVM = new PersonalInfoVM()
            {
                Name = name,
                Age = age,
                Address = address,
                Gender = gender,
                Skills = skills
            };

            return View("PersonalInfomation", PersonalInfoVM);
        }

        public ViewResult PersonalInfo2()
        {
            string name = "Mohamed";
            int age = 27;
            string address = "Mansoura";
            char gender = 'M';

            List<string> skills = new List<string>
        {
            "C", "C++", "C#", "SQL Server"
        };

            var PersonalInfoVM = new PersonalInfoVM()
            {
                Name = name,
                Age = age,
                Address = address,
                Gender = gender,
                Skills = skills
            };

            return View(PersonalInfoVM);
        }
    }
}