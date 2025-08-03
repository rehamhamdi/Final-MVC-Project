using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System.Models
{
    public class OfficeAssignment
    {
        public int Id { get; set; }
        [Required]
        public string? Location { get; set; }

        //Relation between Instructor and OfficeAssignment
        [ForeignKey("instructor")]
        [Display(Name = "Instructor")]
        public int InstructorId { get; set; }
        public Instructor? instructor { get; set; }
    }
}
