using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Relationship between Stuent and Department
        [ForeignKey("department")]
        public int DepartmentId { get; set; }
        //Navigation properties
        public Department? department { get; set; }

        public List<Enrollment>? enrollments { get; set; }

        public List<Attendance>? attendances { get; set; }
    }
}
