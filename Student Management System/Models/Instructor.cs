using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Validators;
using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Name must at least 3 charcters")]
        [Required(ErrorMessage = "This field is required")]
        [UniqueInstructor]
        public string Name { get; set; }
        [Remote("CheckFutureDate" ,"Instructor",ErrorMessage = "Hire Date Can't be in future")]
        public DateTime HireDate { get; set; }
        //Navigation property
        public List<OfficeAssignment>? officeAssignments { get; set; }
        public List<Course>? courses { get; set; }

    }
}
