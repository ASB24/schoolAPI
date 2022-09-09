using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolAPI.Models
{
    public class View
    {
        [Keyless]
        public class GradeRow
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public string StudentLastName { get; set; }
            public int GradeID { get; set; }
            public string Subject { get; set; }
            public int Grade { get; set; }
            public string Literal { get; set; }
        }

        [Keyless]
        public class AttendanceRow
        {
            public int AttendanceID { get; set; }

            [DataType(DataType.Date)]
            [Column(TypeName = "Date")]
            public DateTime AttendanceDate { get; set; }
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public string StudentLastName { get; set; }
            public bool IsPresent { get; set; }
        }
    }
}
