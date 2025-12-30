using Microsoft.AspNetCore.Mvc;

namespace NAKHLA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Category Management";
            ViewBag.PageTitle = "Categories";
            ViewBag.Subtitle = "Manage product categories";
            return View();
        }
    }
}
