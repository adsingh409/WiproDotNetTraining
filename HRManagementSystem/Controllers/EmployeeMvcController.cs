using Microsoft.AspNetCore.Mvc;
using HRManagementSystem.Data;
using HRManagementSystem.Models;

public class EmployeeMvcController : Controller
{
    private readonly AppDbContext _context;

    public EmployeeMvcController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var employees = _context.Employees.ToList();
        return View(employees);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Employee emp)
    {
        if (ModelState.IsValid)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index"); // ya Create bhi rakh sakta hai
        }

        return View(emp);
    }
    public IActionResult Edit(int id)
    {
        var emp = _context.Employees.Find(id);
        return View(emp);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Employee emp)
    {
        _context.Employees.Update(emp);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var emp = _context.Employees.Find(id);
        _context.Employees.Remove(emp);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


}
