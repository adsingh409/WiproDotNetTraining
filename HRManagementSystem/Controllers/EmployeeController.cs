using Microsoft.AspNetCore.Mvc;
using HRManagementSystem.Data;
using HRManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/employee
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        // GET by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return Ok(emp);
        }

        // PUT (Update)
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee emp)
        {
            var existing = _context.Employees.Find(id);

            if (existing == null)
                return NotFound();

            existing.Name = emp.Name;
            existing.Email = emp.Email;
            existing.Role = emp.Role;
            existing.Salary = emp.Salary;

            _context.SaveChanges();

            return Ok(existing);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = _context.Employees.Find(id);

            if (emp == null)
                return NotFound();

            _context.Employees.Remove(emp);
            _context.SaveChanges();

            return Ok("Deleted Successfully");
        }
    }
}
