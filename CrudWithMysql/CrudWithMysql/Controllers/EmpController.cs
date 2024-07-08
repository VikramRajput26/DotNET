using CrudWithMysql.Data;
using CrudWithMysql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWithMysql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private AppDbContext _context;
        public EmpController(AppDbContext appcontext)
        {
            _context = appcontext;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee updatedEmployee)
        {
            if (id != updatedEmployee.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
