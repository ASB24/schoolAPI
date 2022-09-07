using System.ComponentModel.DataAnnotations;

namespace classAPI.Models
{
    public class Student
    {
        [Key, Display(Name = "Student's ID")]
        public int ID { get; set; }

        [Display(Name = "Student's first name")]
        [StringLength(128, ErrorMessage = "Student's first name must be shorter than 128 characters")]
        [Required(ErrorMessage = "Provide a first name for the student")]
        public string Name { get; set; }

        [Display(Name = "Student's last name")]
        [StringLength(128, ErrorMessage = "Student's last name must be shorter than 128 characters")]
        [Required(ErrorMessage = "Provide a last name for the student")]
        public string LastName { get; set; }

        [Display(Name = "Student's class")]
        [StringLength(5, ErrorMessage = "Class name must be shorter than 5 characters")]
        [Required(ErrorMessage = "Provide a class for the student")]
        public string Class { get; set; }

        [Display(Name = "Student's addition date")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Student's last update date")]
        public DateTime LastUpdatedAt { get; set; }

        public Student()
        {
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
        }
    }
}
