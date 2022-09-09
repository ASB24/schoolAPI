using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace schoolAPI.Models
{
    public class Grade
    {
        public static char CalculateLiteral(int grade)
        {
            if (grade >= 90) return 'A';
            else if (grade >= 80) return 'B';
            else if (grade >= 70) return 'C';
            else return 'F';
        }

        [Key]
        [Display(Name = "Grade's ID")]
        public int ID { get; set; }

        [Display(Name = "Grade's Subject")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Subject name must be between 3 and 60 characters")]
        [Required(ErrorMessage = "Provide a subject name")]
        public string Subject { get; set; }

        [Display(Name = "Grade's Score")]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        [Required(ErrorMessage = "Provide a score for the grade")]
        public int GradeScore { get; set; }

        [Display(Name = "Grade's Literal")]
        [RegularExpression("A|B|C|F")]
        public char Literal { get; set; }

        [ForeignKey("Student")]
        [Required(ErrorMessage = "Enter a valid Student ID")]
        [Display(Name = "Grade's Student ID")]
        public int StudentID { get; set; }

        [Display(Name = "Grade's Creation Date")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Grade's Last Update Date")]
        public DateTime LastUpdatedAt { get; set; }

        public Grade()
        {
            Literal = Grade.CalculateLiteral(GradeScore);
        }

    }
}
