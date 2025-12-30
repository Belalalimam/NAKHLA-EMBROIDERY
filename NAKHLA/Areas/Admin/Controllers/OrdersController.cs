using Microsoft.AspNetCore.Mvc;

namespace NAKHLA.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Orders Dashboard";
            ViewBag.PageTitle = "Orders";
            return View();
        }

        public IActionResult Inventory()
        {
            ViewBag.PageTitle = "Inventory";
            return View();
        }

        public IActionResult Payments()
        {
            ViewBag.PageTitle = "Payments";
            return View();
        }

        public IActionResult Customers()
        {
            ViewBag.PageTitle = "Customers";
            return View();
        }

        public IActionResult Notifications()
        {
            ViewBag.PageTitle = "Notifications";
            return View();
        }

        public IActionResult Help()
        {
            ViewBag.PageTitle = "Help & Support";
            return View();
        }

        public IActionResult Settings()
        {
            ViewBag.PageTitle = "Settings";
            return View();
        }
    }
}