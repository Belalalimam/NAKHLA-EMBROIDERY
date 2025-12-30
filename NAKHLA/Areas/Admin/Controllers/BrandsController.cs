using Microsoft.AspNetCore.Mvc;

namespace NAKHLA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Brand Management";
            ViewBag.PageTitle = "Brands";
            ViewBag.Subtitle = "Manage product brands";
            return View();
        }
    }
}
