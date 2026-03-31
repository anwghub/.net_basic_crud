using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.Data;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IActionResult> Create(Student student)
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
        public async Task<IActionResult> Update(int id, Student updatedStudent)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Hobby = updatedStudent.Hobby;
            student.Age = updatedStudent.Age;

            await _context.SaveChangesAsync();

            return Ok(updatedStudent);
        }

        //delete
        [HttpDelete]
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