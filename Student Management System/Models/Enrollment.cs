using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        //Relation between Student and Enrollment
        [ForeignKey("student")]
        public int StudentId { get; set; }
        public Student? student { get; set; }

        //Relation between Course and Enrollment
        [ForeignKey("course")]
        public int CourseId { get; set; }
        public Course? course { get; set; }

        public int Grade { get; set; }

    }
}
