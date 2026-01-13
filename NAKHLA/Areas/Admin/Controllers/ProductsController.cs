using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAKHLA.DataAccess;
using NAKHLA.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NAKHLA.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.SUPER_ADMIN_ROLE},{SD.ADMIN_ROLE},{SD.EMPLOYEE_ROLE}")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalProducts = await _context.Products.CountAsync(p => !p.IsDeleted);
            var totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

            ViewBag.TotalProducts = totalProducts;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize;

            // Calculate stats
            var stats = new
            {
                TotalProducts = totalProducts,
                InStock = await _context.Products.CountAsync(p => !p.IsDeleted && p.StockQuantity > 0),
                OutOfStock = await _context.Products.CountAsync(p => !p.IsDeleted && p.StockQuantity == 0),
                LowStock = await _context.Products.CountAsync(p => !p.IsDeleted && p.StockQuantity <= 10 && p.StockQuantity > 0)
            };

            ViewBag.Stats = stats;

            return View(products);
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            return View(product);
        }

        // GET: Admin/Products/GetDetails/5
        [HttpGet]
        public async Task<IActionResult> GetDetails(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            return PartialView("_DetailsPartial", product);
        }

        // GET: Admin/Products/Create
        public async Task<IActionResult> Create()
        {
            // Get active categories
            var categories = await _context.Categorise
                .Where(c => c.Status == CategoryStatus.Active)
                .ToListAsync();

            // Get active brands
            var brands = await _context.Brands
                .Where(b => b.Status == "Active")
                .ToListAsync();

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;

            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            // Debug: Check what's coming in
            Console.WriteLine($"Product Name: {product?.Name}");
            Console.WriteLine($"Product SKU: {product?.SKU}");
            Console.WriteLine($"Product Price: {product?.Price}");
            Console.WriteLine($"Product CategoryId: {product?.CategoryId}");

            if (ModelState.IsValid)
            {
                try
                {
                    // Set defaults
                    product.CreatedAt = DateTime.Now;
                    product.CreatedBy = User.Identity?.Name ?? "System";
                    product.IsDeleted = false;

                    // Generate SKU if empty
                    if (string.IsNullOrEmpty(product.SKU))
                    {
                        product.SKU = "PROD-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                    }

                    // Generate slug if empty
                    if (string.IsNullOrEmpty(product.Slug))
                    {
                        product.Slug = GenerateSlug(product.Name);
                    }

                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Product created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the error
                    Console.WriteLine($"Error saving product: {ex.Message}");
                    ModelState.AddModelError("", $"Error saving product: {ex.Message}");
                }
            }
            else
            {
                // Show validation errors
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                Console.WriteLine($"Validation errors: {string.Join(", ", errors)}");

                // Add errors to ViewBag to display in view
                ViewBag.ValidationErrors = errors.ToList();
            }

            // If validation fails, reload dropdowns
            // Use _context.Categorise (not Categories)
            var categories = await _context.Categorise
                .Where(c => c.Status == CategoryStatus.Active)
                .ToListAsync();

            var brands = await _context.Brands
                .Where(b => b.Status == "Active")
                .ToListAsync();

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;

            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            // Get dropdown data
            var categories = await _context.Categorise
                .Where(c => c.Status == CategoryStatus.Active)
                .ToListAsync();

            var brands = await _context.Brands
                .Where(b => b.Status == "Active")
                .ToListAsync();

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;

            return View(product);
        }

        // GET: Admin/Products/GetEdit/5
        [HttpGet]
        public async Task<IActionResult> GetEdit(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            // Get dropdown data
            var categories = await _context.Categorise
                .Where(c => c.Status == CategoryStatus.Active)
                .ToListAsync();

            var brands = await _context.Brands
                .Where(b => b.Status == "Active")
                .ToListAsync();

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;

            return PartialView("_EditPartial", product);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    product.UpdatedAt = DateTime.Now;
                    product.UpdatedBy = User.Identity?.Name ?? "System";

                    _context.Products.Update(product);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Product updated successfully!";
                    return Json(new { success = true, message = "Product updated successfully!" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }

            // If validation fails
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return Json(new { success = false, errors = errors });
        }

        // POST: Admin/Products/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return Json(new { success = false, message = "Product not found!" });
                }

                // Soft delete
                product.IsDeleted = true;
                product.DeletedAt = DateTime.Now;
                product.DeletedBy = User.Identity?.Name ?? "System";

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Product deleted successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }

        // POST: Admin/Products/DeleteMultiple
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            try
            {
                if (ids == null || !ids.Any())
                {
                    return Json(new { success = false, message = "No products selected" });
                }

                var products = await _context.Products
                    .Where(p => ids.Contains(p.Id))
                    .ToListAsync();

                foreach (var product in products)
                {
                    product.IsDeleted = true;
                    product.DeletedAt = DateTime.Now;
                    product.DeletedBy = User.Identity?.Name ?? "System";
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true, message = $"{products.Count} product(s) deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private string GenerateSlug(string name)
        {
            if (string.IsNullOrEmpty(name)) return "";

            return name.ToLower()
                .Trim()
                .Replace(" ", "-")
                .Replace("--", "-")
                .Replace("---", "-");
        }
    }
}