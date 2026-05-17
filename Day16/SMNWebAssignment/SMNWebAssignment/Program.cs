var builder = WebApplication.CreateBuilder(args);

// MVC + Razor dono enable
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseRouting();

// MVC routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Razor Pages routing
app.MapRazorPages();

// Custom route (Assignment requirement)
app.MapGet("/Products/{id:int}", async context =>
{
    var id = context.Request.RouteValues["id"];
    await context.Response.WriteAsync($"Product ID: {id}");
});

app.Run();
