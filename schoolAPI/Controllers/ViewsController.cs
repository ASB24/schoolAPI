using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using schoolAPI.Models;

namespace schoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewsController : Controller
    {
        private readonly SchoolContext schoolContext;
        public ViewsController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        [HttpGet]
        [Route("grades")]
        public async Task<ActionResult<IEnumerable<View.GradeRow>>> GetRows()
        {
            if (schoolContext.GradesView == null)
            {
                return NotFound();
            }
            return await schoolContext.GradesView.FromSqlRaw("select * from grades_view").ToListAsync();
        }

        [HttpGet]
        [Route("attendances")]
        public async Task<ActionResult<IEnumerable<View.AttendanceRow>>> GetAttendances()
        {
            if (schoolContext.AttendancesView == null)
            {
                return NotFound();
            }
            return await schoolContext.AttendancesView.FromSqlRaw("select * from attendances_view").ToListAsync();
        }
    }
}
