using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System.Models
{
    public class Student
    {
        public int Id { get; set; }
        [MinLength(3,ErrorMessage ="Name must at least 3 charcters")]
        [Required(ErrorMessage ="This field is required")]
        [UniqueStudent]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [Display(Name="Date Of Birth")]
        [Remote("CheckDate","Student", ErrorMessage ="Year of DateOfBirth must be < 2010")]
        public DateTime DateOfBirth { get; set; }

        //Relationship between Stuent and Department
        [ForeignKey("department")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        //Navigation properties
        public Department? department { get; set; }

        public List<Enrollment>? enrollments { get; set; }

        public List<Attendance>? attendances { get; set; }
    }
}
