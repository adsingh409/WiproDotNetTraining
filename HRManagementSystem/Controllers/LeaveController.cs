using HRManagementSystem.Data;
using HRManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeaveController(AppDbContext context)
        {
            _context = context;
        }

        // GE[HttpGet]

        [HttpGet]
        public IActionResult GetLeaves()
        {
            var leaves = _context.Leaves
                .Include(l => l.Employee)
                .Select(l => new
                {
                    l.Id,
                    EmployeeName = l.Employee != null ? l.Employee.Name : "No Employee",
                    Email = l.Employee != null ? l.Employee.Email : "N/A",
                    l.StartDate,
                    l.EndDate,
                    l.Status
                })
                .ToList();

            return Ok(leaves);
        }



        // APPLY leave
        [HttpPost]
        public IActionResult ApplyLeave(Leave leave)
        {
            _context.Leaves.Add(leave);
            _context.SaveChanges();
            return Ok(leave);
        }
    }
}
