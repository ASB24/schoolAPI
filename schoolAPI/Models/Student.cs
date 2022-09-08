using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolAPI.Models
{
    public class Student
    {
        [Key, Display(Name = "Student's ID")]
        public int ID { get; set; }

        [Display(Name = "Student's First Name")]
        [StringLength(128, ErrorMessage = "Student's first name must be shorter than 128 characters")]
        [Required(ErrorMessage = "Provide a first name for the student")]
        public string Name { get; set; }

        [Display(Name = "Student's Last Name")]
        [StringLength(128, ErrorMessage = "Student's last name must be shorter than 128 characters")]
        [Required(ErrorMessage = "Provide a last name for the student")]
        public string LastName { get; set; }

        [Display(Name = "Student's Class")]
        [StringLength(5, ErrorMessage = "Class name must be shorter than 5 characters")]
        [Required(ErrorMessage = "Provide a class for the student")]
        public string Class { get; set; }

        [Display(Name = "Student's Creation Date")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Student's Last Update Date")]
        public DateTime LastUpdatedAt { get; set; }
    }
}
