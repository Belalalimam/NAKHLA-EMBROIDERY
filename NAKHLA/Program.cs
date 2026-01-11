using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NAKHLA;
using NAKHLA.Configurations;
using NAKHLA.DataAccess;
using NAKHLA.Utitlies.DBInitilizer;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
                    builder.Configuration.GetConnectionString("DefaultConnection")
                        ?? throw new InvalidOperationException("Connection string"
                        + "'DefaultConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.RegisterConfig(connectionString);
builder.Services.RegisterMapsterConfig();
var app = builder.Build();

var scope = app.Services.CreateScope();
var service = scope.ServiceProvider.GetService<IDBInitializer>();
service!.Initialize();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();   
app.UseAuthorization();



app.MapStaticAssets();
//app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "root",
    pattern: "",
    defaults: new { area = "Customer", controller = "Home", action = "Index" }
);



app.Run();
