using System.ComponentModel.DataAnnotations;

namespace classAPI.Models
{
    public class Attendance
    {
        [Key, Display(Name = "Attendance ID")]
        public int AttendanceID { get; set; }

        [Display(Name = "Attendance date"), Required(ErrorMessage = "Provide a valid for the attendance list date")]
        public DateTime AttendanceDate { get; set; }

        [Display(Name = "Is Present?"), Required(ErrorMessage = "Provide a valid boolean for whether the student was present or not")]
        public bool Grade { get; set; }

        [Display(Name = "Creation date of attendance")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Attendance's last update date")]
        public DateTime LastUpdatedAt { get; set; }

        [Display(Name = "Student's ID"), Required(ErrorMessage = "Provide a valid Student ID")]
        public int StudentID { get; set; }
        [Display(Name = "Student of attendance")]
        public Student Student { get; set; }

        public Attendance()
        {
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
        }
    }
}
