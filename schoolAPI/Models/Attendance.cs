using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolAPI.Models
{
    public class Attendance
    {
        [Key]
        [Display(Name = "Attendance ID")]
        public int ID { get; set; }

        [Display(Name = "Attendance Date")]
        [Required(ErrorMessage = "Provide a valid for the attendance list date")]
        public DateTime AttendanceDate { get; set; }

        [Display(Name = "Is Present?")]
        [Required(ErrorMessage = "Provide a valid boolean for whether the student was present or not")]
        public bool IsPresent { get; set; }

        [Display(Name = "Attendance's Creation Date")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Attendance's Last Update Date")]
        public DateTime LastUpdatedAt { get; set; }

        [Display(Name = "Student's ID")]
        [Required(ErrorMessage = "Provide a valid Student ID")]
        public int StudentID { get; set; }
        [Display(Name = "Student of Attendance")]
        public Student Student { get; set; }
    }
}
