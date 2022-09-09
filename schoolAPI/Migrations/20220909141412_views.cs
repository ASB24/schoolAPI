using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolAPI.Migrations
{
    public partial class views : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("GO\r\n" +
                "create view grades_view as\r\n" +
                "select " +
                "Students.ID as [StudentID], Students.Name as StudentName, Students.LastName as StudentLastName,\r\n\t   " +
                "Grades.ID as [GradeID], Grades.Subject, Grades.GradeScore as [Grade], Grades.Literal\r\n" +
                "from Grades\r\n" +
                "inner join Students on Students.ID = Grades.StudentID\r\n\r\n" +
                "GO\r\n\r\n" +
                "create view attendances_view as\r\n" +
                "select Attendances.ID as [AttendanceID], Attendances.AttendanceDate, " +
                "Students.ID as [StudentID], \r\n\t   Students.Name as [StudentName], " +
                "Students.LastName as [StudentLastName], Attendances.IsPresent\r\n" +
                "from Attendances\r\n" +
                "inner join Students on Students.ID = Attendances.StudentID\r\n\r\n" +
                "GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("" +
                "drop view grades_view\r\n" +
                "drop view attendances_view");
        }
    }
}
