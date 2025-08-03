using Student_Management_System.Validators;
using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Department
    {
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "Name must at least 2 charcters")]
        [Required(ErrorMessage = "This field is required")]
        [UniqueDepartment]
        public string Name { get; set; }
        //Navigation property
        public List<Student>? students { get; set; }
    }
}
