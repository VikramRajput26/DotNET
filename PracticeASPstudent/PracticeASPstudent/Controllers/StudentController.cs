using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeASPstudent.Model;
using PracticeASPstudent.Repositories;

namespace PracticeASPstudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentCollectionContext _context;
        public StudentController(StudentCollectionContext context) {
            _context = context;
        
        }

        public async Task<IActionResult> GetAll() { 
        var student = await _context.Students.ToListAsync();
            return Ok(student);
        }

        public async Task<IActionResult> delete(int id) {
            var student = await _context.Students.FindAsync(id);
             _context.Students.Remove(student);
            return Ok(student);
        
        }
        public async Task<IActionResult> Update(int id, Student updatedStudent) {
            if (id != updatedStudent.id) {
                return BadRequest();
            }
            _context.Entry(updatedStudent).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        
        }

    }
}
