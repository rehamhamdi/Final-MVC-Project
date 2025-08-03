using Student_Management_System.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System.Models
{
    public class Course
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Name must at least 3 charcters")]
        [Required(ErrorMessage = "This field is required")]
        [UniqueCourse]
        public string Name { get; set; }
        [Required]
        public int CreditsHours { get; set; }
        //Navigation Properties
        public List<Enrollment>? enrollments { get; set; }
        public List<Attendance>? attendances { get; set; }
        //Relation between Course and Instructor
        [ForeignKey("Instructor")]
        [Display(Name="Instructor")]
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }

    }
}
