using Microsoft.AspNetCore.Mvc;

namespace NAKHLA.Areas.Identity.Controllers
{
    public class ProfileController : Controller
    {
        [Area("Identity")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
