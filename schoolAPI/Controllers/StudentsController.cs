using classAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace classAPI.Controllers
{
    [Route("api/[controller]")] //Hardcoded
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly SchoolContext schoolContext;

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
        //POST: api/students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            schoolContext.Students.Add(student);
            await schoolContext.SaveChangesAsync();

            return student;
        }
    }
}
