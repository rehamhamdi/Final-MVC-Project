using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        [Required]
        [Range(0,100,ErrorMessage ="The grade must be between 0 to 100")]
        public int Grade { get; set; }


        //Relation between Student and Enrollment
        [ForeignKey("student")]
        [Display(Name ="Student")]
        public int StudentId { get; set; }
        public Student? student { get; set; }

        //Relation between Course and Enrollment
        [ForeignKey("course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course? course { get; set; }

    }
}
