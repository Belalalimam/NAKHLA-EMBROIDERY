using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAKHLA.DataAccess; // تأكد من المسار الصحيح للـ DbContext

public class NavMenuViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _db;

    public NavMenuViewComponent(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        // جلب البيانات من الجداول التي ذكرتها
        var viewModel = new NavMenuViewModel
        {
            FabricTypes = await _db.FabricTypes.ToListAsync(),
            ProjectCategories = await _db.ProjectCategories.ToListAsync(),
            ProductColors = await _db.ProductColors.ToListAsync()
        };

        return View(viewModel);
    }
}

// ViewModel بسيط لنقل البيانات للواجهة
public class NavMenuViewModel
{
    public List<NAKHLA.Models.FabricType> FabricTypes { get; set; }
    public List<NAKHLA.Models.ProjectCategory> ProjectCategories { get; set; }
    public List<NAKHLA.Models.ProductColor> ProductColors { get; set; }
}