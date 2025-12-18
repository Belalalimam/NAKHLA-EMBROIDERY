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
        public IActionResult Index()
        {

            var products = _context.Products.AsQueryable();

           


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
    }
}