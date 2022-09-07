using System.ComponentModel.DataAnnotations;

namespace classAPI.Models
{
    public class AttendanceList
    {
        [Key]
        public int AttendanceID { get; set; }

        [Display(Name = "Attendance date"), Required(ErrorMessage = "Provide a valid for the attendance list date")]
        public DateTime AttendanceDate { get; set; }

        [Display(Name = "Is Present?"), Required(ErrorMessage = "Provide a valid boolean for whether the student was present or not")]
        public bool Grade { get; set; }

        [Display(Name = "Student's ID"), Required(ErrorMessage = "Provide a valid Student ID")]
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
