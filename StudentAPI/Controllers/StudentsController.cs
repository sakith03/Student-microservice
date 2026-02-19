using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Models;

namespace StudentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/students
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        return await _context.Students.ToListAsync();
    }

    // GET: api/students/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound(new { message = $"Student with ID {id} not found." });
        return student;
    }

    // POST: api/students
    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent(Student student)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        student.Id = 0; // let EF assign
        student.EnrolledDate = DateTime.UtcNow;
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    // PUT: api/students/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, Student student)
    {
        if (id != student.Id) return BadRequest(new { message = "ID mismatch." });

        var existing = await _context.Students.FindAsync(id);
        if (existing == null) return NotFound(new { message = $"Student with ID {id} not found." });

        existing.FirstName = student.FirstName;
        existing.LastName = student.LastName;
        existing.Email = student.Email;
        existing.Age = student.Age;
        existing.Course = student.Course;

        await _context.SaveChangesAsync();
        return Ok(existing);
    }

    // DELETE: api/students/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound(new { message = $"Student with ID {id} not found." });

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return Ok(new { message = $"Student '{student.FirstName} {student.LastName}' deleted successfully." });
    }
}
