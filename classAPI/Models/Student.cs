using System.ComponentModel.DataAnnotations;

namespace classAPI.Models
{
    public class Student
    {
        [Key, Display(Name = "Student's ID")]
        public int StudentID { get; set; }

        [Display(Name = "Student's first name"), StringLength(128), Required(ErrorMessage = "Provide a first name for the student")]
        public string Name { get; set; }

        [Display(Name = "Student's last name"), StringLength(128), Required(ErrorMessage = "Provide a last name for the student")]
        public string LastName { get; set; }

        [Display(Name = "Student's class"), StringLength(5), Required(ErrorMessage = "Provide a class for the student")]
        public string Class { get; set; }

        [Display(Name = "Student's addition date")]
        public DateTime CreatedAt { get; set; }
    }
}
