using BookStoreApp.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services with Filters
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(LoggingFilter));
    options.Filters.Add(typeof(ErrorFilter));
});

// Session
builder.Services.AddSession();

// Razor Pages support
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

// MVC Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

// Razor Pages Routing
app.MapRazorPages();

app.Run();