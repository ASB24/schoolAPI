using schoolAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace schoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : Controller
    {
        private readonly SchoolContext schoolContext;
        private bool GradeExists(int id) { return (schoolContext.Grades?.Any(s => s.ID == id)).GetValueOrDefault(); }

        public GradesController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        //GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            if (schoolContext.Grades == null)
            {
                return NotFound();
            }

            return await schoolContext.Grades.ToListAsync();
        }

        //GET: api/Grades/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            if (schoolContext.Grades == null)
            {
                return NotFound();
            }

            var grade = await schoolContext.Grades.FindAsync(id);
            if (grade == null) return NotFound();



            return grade;
        }

        // TODO: rest of endpoints and endpoints for grades and attendance
        //POST: api/Grades
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
            var student = await schoolContext.Students.FindAsync(grade.StudentID);
            if (student == null) return NotFound("Student with provided Student ID not found");
            
            grade.CreatedAt = DateTime.Now;
            grade.LastUpdatedAt = DateTime.Now;

            schoolContext.Grades.Add(grade);
            await schoolContext.SaveChangesAsync();

            return grade;
        }

        [HttpPut]
        public async Task<IActionResult> PutGrade(Grade grade)
        {
            var student = await schoolContext.Students.FindAsync(grade.StudentID);
            if (student == null) return NotFound("Student with provided Student ID not found");

            schoolContext.Entry(grade).State = EntityState.Modified;

            try
            {
                grade.LastUpdatedAt = DateTime.Now;
                await schoolContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!GradeExists(grade.ID))
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

        //DELETE: api/Grades/{id}
        [HttpDelete]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            if (schoolContext.Grades == null) return NotFound();

            var grade = await schoolContext.Grades.FindAsync(id);
            if (grade == null) return NotFound();

            schoolContext.Grades.Remove(grade);
            await schoolContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
