using crud.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        //create
        [HttpPost]
        public async Task<IActionResult> Create(Trainee student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        //get All
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var student = await _context.Students.ToListAsync();
            return Ok(student);
        }

        //get by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        //Update
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, Trainee updatedStudent)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            if (!string.IsNullOrEmpty(updatedStudent.Name))
            {
                student.Name = updatedStudent.Name;
            }
            if (!string.IsNullOrEmpty(updatedStudent.Email))
            {
                student.Email = updatedStudent.Email;
            }
            if (!string.IsNullOrEmpty(updatedStudent.Hobby))
            {
                student.Hobby = updatedStudent.Hobby;
            }

            student.Age = updatedStudent.Age;

            await _context.SaveChangesAsync();

            return Ok(student);
        }

        //delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok("Deleted");

        }
    }
}