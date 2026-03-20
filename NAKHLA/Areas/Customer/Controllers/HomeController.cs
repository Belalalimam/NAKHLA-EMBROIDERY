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
            return View();
        }
        public IActionResult Product(FilterVM filterVM, int page = 1)
        {
            const int discount = 50;
            var products = _context.Products.Where(p => !p.IsDeleted).AsQueryable();

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

            products = products.Skip((page - 1) * 16).Take(16);


            return View(products.ToList());
        }

        public IActionResult CategroySearch(FilterVM filterVM, int page = 1)
        {
            const int discount = 50;

            var products = _context.Products
                .Include(e => e.Category)
                .AsQueryable();

            Category? category = null;

            if (filterVM.CategoryId is not null)
            {
                products = products.Where(e => e.CategoryId == filterVM.CategoryId);
                category = _context.Categorise
                    .FirstOrDefault(e => e.Id == filterVM.CategoryId);

                ViewBag.CategoryId = filterVM.CategoryId;
            }

            // باقي الفلاتر
            if (filterVM.Name is not null)
                products = products.Where(e => e.Name.Contains(filterVM.Name));

            if (filterVM.IsHot)
                products = products.Where(e => e.Discount >= discount);

            // pagination
            var totalNumberOfPages = Math.Ceiling(products.Count() / 8.0);
            ViewBag.totalNumberOfPages = totalNumberOfPages;
            ViewBag.currentPage = page;

            products = products.Skip((page - 1) * 8).Take(8);

            // 🔴 أهم سطر
            ViewBag.SelectedCategory = category;

            return View(products.ToList());
        }


        [HttpGet("fabrics-used-for/{slug}")]
        public IActionResult FabricsUsedFor(string slug)
        {
            var products = _context.Products
                .Include(p => p.ProjectCategories)
                .Include(p => p.FabricType)
                .Where(p => p.ProjectCategories.Any(c => c.Slug == slug))
                .ToList();

            ViewBag.Title = slug;
            return View("Product", products);
        }


        [HttpGet("fabric-type/{slug}")]
        public IActionResult FabricType(string slug)
        {
            var products = _context.Products
                .Include(p => p.FabricType)
                .Where(p => p.FabricType.Slug == slug)
                .ToList();

            ViewBag.Title = slug;
            return View("Product", products);
        }




        public IActionResult FilterByColor(string color)
        {
            var products = _context.Products
                .Include(p => p.Color)
                .ToList();

            ViewBag.categories = _context.Categorise.ToList();
            ViewBag.Title = $"Color: {color}";
            return View("Product", products);
        }




        public IActionResult Details(int id)
        {
            // 1. جلب بيانات المنتج مع كافة العلاقات الضرورية لمنع خطأ الـ Null أو الـ InvalidOperation
            var product = _context.Products
        .Include(e => e.Category)
        .Include(p => p.ProjectCategories)
        .Include(e => e.ProductImages)
        .Include(p => p.Color) // تم حذف ThenInclude للون لأنه string وليس كائن
        .Include(p => p.ProductCompositions)
            .ThenInclude(pc => pc.Composition) // هذا يبقى كما هو لأن Composition كائن
        .FirstOrDefault(e => e.Id == id && !e.IsDeleted);

            // التحقق من وجود المنتج
            if (product is null)
                return RedirectToAction(nameof(NotFoundPage));

            // تحديث عدد المشاهدات
            product.Traffic += 1;
            _context.SaveChanges();

            // 2. جلب المنتجات ذات الصلة (نفس القسم)
            var relatedProducts = _context.Products
                .Include(e => e.Category)
                .Where(e => e.CategoryId == product.CategoryId && e.Name == product.Name && e.Id != product.Id && !e.IsDeleted)
                .Take(4).ToList();

            // 3. جلب المنتجات الأكثر رواجاً
            var topProducts = _context.Products
                .Include(e => e.Category)
                .Where(e => e.Id != product.Id && !e.IsDeleted)
                .OrderByDescending(e => e.Traffic).Take(4).ToList();

            // 4. جلب المنتجات المتشابهة بالاسم
            var similarProducts = _context.Products
                .Include(e => e.Category)
                .Where(e => e.Name.Contains(product.Name) && e.Id != product.Id)
                .Take(4)
                .ToList();

            // 5. تجهيز الصور
            var productImages = product.ProductImages?
                .OrderBy(pi => pi.DisplayOrder)
                .ToList() ?? new List<ProductImage>();

            // 6. تجهيز الـ ViewModel مع حل مشكلة تكرار المكونات
            var viewModel = new ProductWithRelatedVM()
            {
                Product = product,
                RelatedProducts = relatedProducts,
                TopProducts = topProducts,
                SimilarProducts = similarProducts,
                ProductImages = productImages,

                // الحل السحري للتكرار: GroupBy تضمن ظهور كل مكون مرة واحدة فقط
                SelectedCompositions = product.ProductCompositions
                    .Where(pc => pc.Composition != null) // تأمين إضافي ضد الـ Null
                    .GroupBy(pc => pc.Composition.Name)
                    .Select(g => new ProductCompositionVM
                    {
                        CompositionName = g.Key,
                        Percentage = g.First().Percentage // يأخذ النسبة من أول سجل في المجموعة
                    }).ToList()
            };

            // إرسال الكاتيجوري للـ View لضمان عدم حدوث خطأ في القائمة الجانبية
            ViewBag.categories = _context.Categorise.ToList();

            return View(viewModel);
        }


        public IActionResult NotFoundPage()
        {
            return View();
        }



        [HttpGet("filter-by-composition/{id}")]
        public IActionResult FilterByComposition(int id)
        {
            var products = _context.Products
                .Include(p => p.ProductCompositions)
                .Where(p => p.ProductCompositions.Any(pc => pc.CompositionId == id))
                .ToList();

            var compName = _context.Compositions.Find(id)?.Name;
            ViewBag.Title = $"Fabrics with {compName}";

            return View("Product", products);
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