var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1. Middleware: Logging
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"Response: {context.Response.StatusCode}");
});

// 2. Error Handling
app.UseExceptionHandler("/error");

// 3. HTTPS Redirection
app.UseHttpsRedirection();

// 4. Security (Content Security Policy)
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy",
        "default-src 'self'; script-src 'self'; style-src 'self';");
    await next();
});

// 5. Static Files Enable
app.UseStaticFiles();

// Default Route
app.MapGet("/", () => "Assignment 1 Running 🚀");

// Error Route
app.Map("/error", () => "Custom Error Page");

app.Run();


