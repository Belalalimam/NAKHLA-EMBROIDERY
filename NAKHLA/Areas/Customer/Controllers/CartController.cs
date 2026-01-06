using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAKHLA.DataAccess;
using NAKHLA.Utitlies;
using NAKHLA.ViewModels;

namespace NAKHLA.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AddCart()
        {
            return Ok();
        }



    }
}