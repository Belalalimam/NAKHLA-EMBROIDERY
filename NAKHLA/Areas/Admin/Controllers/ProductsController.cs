using Microsoft.AspNetCore.Mvc;

namespace NAKHLA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Product Management";
            ViewBag.PageTitle = "Products";
            ViewBag.Subtitle = "Manage your products";
            return View();
        }
    }
}
