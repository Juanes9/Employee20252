using Employee.Backend.Data;
using Employee.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(c => c.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(EmployeeBD employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(c => c.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(EmployeeBD employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
    }
}