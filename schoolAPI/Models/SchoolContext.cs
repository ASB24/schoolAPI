using Microsoft.EntityFrameworkCore;

namespace schoolAPI.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<View.GradeRow> GradesView { get; set; } = null!;
        public DbSet<View.AttendanceRow> AttendancesView { get; set; } = null!;

    }
}
