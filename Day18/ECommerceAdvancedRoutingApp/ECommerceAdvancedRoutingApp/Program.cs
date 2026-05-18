using ECommerceAdvancedRoutingApp.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

// Register Constraints
builder.Services.Configure<RouteOptions>(options =>
{
    
    options.ConstraintMap.Add("category", typeof(CategoryConstraint));
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Custom Routes

// Product Details
app.MapControllerRoute(
    name: "productRoute",
    pattern: "Products/{category:category}/{id:int}",
    defaults: new { controller = "Products", action = "Details" });

// Product Filter
app.MapControllerRoute(
    name: "filterRoute",
    pattern: "Products/Filter/{category:category}/{priceRange}",
    defaults: new { controller = "Products", action = "Filter" });

// User Orders
app.MapControllerRoute(
    name: "userOrders",
    pattern: "Users/{username}/Orders",
    defaults: new { controller = "Users", action = "Orders" });

// GUID Route
app.MapControllerRoute(
    name: "guidRoute",
    pattern: "Product/{id:guid}",
    defaults: new { controller = "Products", action = "Details" });

// Default
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();