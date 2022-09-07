using System.ComponentModel.DataAnnotations;

namespace classAPI.Models
{
    public class Grade
    {
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

        [Display(Name = "Grade's creation date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Grade's last update date")]
        public DateTime LastUpdatedAt { get; set; }

        [Display(Name = "Grade's Student ID")]
        public int StudentID { get; set; }

        [Display(Name = "Grade's Student")]
        public Student Student { get; set; }

        public Grade()
        {
            CreatedDate = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
        }

    }
}
