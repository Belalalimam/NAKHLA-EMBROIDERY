using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NAKHLA.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
                return View(registerVM);

            await _userManager.CreateAsync(new()
            {
                Name = registerVM.Name,
                UserName = registerVM.UserName,
            });
            return View();
        }
        
    }
}