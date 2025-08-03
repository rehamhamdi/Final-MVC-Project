using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        //Relation between Student and Attendance
        [ForeignKey("student")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public Student? student { get; set; }

        //Relation between Course and Attendance
        [ForeignKey("course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course? course { get; set; }
        [Remote("CheckFutureDate", "Attendance", ErrorMessage = "Date Can't be in future")]

        public DateTime Date { get; set; }

        [Display(Name ="Is Present?")]
        public bool IsPresent { get; set; }

    }
}
