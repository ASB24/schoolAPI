using schoolAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace schoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly SchoolContext schoolContext;
        private bool StudentExists(int id) { return (schoolContext.Students?.Any(s => s.ID == id)).GetValueOrDefault(); }

        public StudentsController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        //GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            if(schoolContext.Students == null)
            {
                return NotFound();
            }

            return await schoolContext.Students.ToListAsync();
        }

        //GET: api/Students/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            if(schoolContext.Students == null)
            {
                return NotFound();
            }

            var student = await schoolContext.Students.FindAsync(id);
            if(student == null) return NotFound();

            

            return student;
        }

        // TODO: rest of endpoints and endpoints for grades and attendance
        //POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            schoolContext.Students.Add(student);
            await schoolContext.SaveChangesAsync();

            return student;
        }

        //PUT: api/Students/{id}
        [HttpPut]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.ID) return BadRequest();

            schoolContext.Entry(student).State = EntityState.Modified;

            try
            {
                student.LastUpdatedAt = DateTime.Now;
                await schoolContext.SaveChangesAsync();
            }
            catch( DbUpdateConcurrencyException ex )
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }

            return NoContent();
        }

        //DELETE: api/Students/{id}
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (schoolContext.Students == null) return NotFound();

            var student = await schoolContext.Students.FindAsync(id);
            if (student == null) return NotFound();

            schoolContext.Students.Remove(student);
            await schoolContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
