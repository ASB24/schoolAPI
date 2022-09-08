using schoolAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace schoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : Controller
    {
        private readonly SchoolContext schoolContext;
        private bool AttendanceExists(int id) { return (schoolContext.Attendances?.Any(s => s.ID == id)).GetValueOrDefault(); }

        public AttendancesController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        //GET: api/Attendances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendances()
        {
            if (schoolContext.Attendances == null)
            {
                return NotFound();
            }

            return await schoolContext.Attendances.ToListAsync();
        }

        //GET: api/Attendances/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendance(int id)
        {
            if (schoolContext.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await schoolContext.Attendances.FindAsync(id);
            if (attendance == null) return NotFound();



            return attendance;
        }

        //POST: api/Attendances
        [HttpPost]
        public async Task<ActionResult<Attendance>> PostAttendance(Attendance attendance)
        {
            var student = await schoolContext.Students.FindAsync(attendance.StudentID);
            if (student == null) return NotFound("Student with provided Student ID not found");

            attendance.CreatedAt = DateTime.Now;
            attendance.LastUpdatedAt = DateTime.Now;

            schoolContext.Attendances.Add(attendance);
            await schoolContext.SaveChangesAsync();

            return attendance;
        }

        //PUT: api/Attendances/{id}
        [HttpPut]
        public async Task<IActionResult> PutAttendance(Attendance attendance)
        {
            var student = schoolContext.Students.Find(attendance.StudentID);
            if (student == null) return NotFound("Student with provided Student ID not found");

            schoolContext.Entry(attendance).State = EntityState.Modified;

            try
            {
                attendance.LastUpdatedAt = DateTime.Now;
                await schoolContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!AttendanceExists(attendance.ID))
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

        //DELETE: api/Attendances/{id}
        [HttpDelete]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            if (schoolContext.Attendances == null) return NotFound();

            var attendance = await schoolContext.Attendances.FindAsync(id);
            if (attendance == null) return NotFound();

            schoolContext.Attendances.Remove(attendance);
            await schoolContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
