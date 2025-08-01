using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        //Relation between Student and Attendance
        [ForeignKey("student")]
        public int StudentId { get; set; }
        public Student? student { get; set; }

        //Relation between Course and Attendance
        [ForeignKey("course")]
        public int CourseId { get; set; }
        public Course? course { get; set; }

        public DateTime Date { get; set; }

        public bool IsPresent { get; set; }

    }
}
