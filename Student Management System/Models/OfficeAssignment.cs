using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System.Models
{
    public class OfficeAssignment
    {
        public int Id { get; set; }
        public string? Location { get; set; }

        //Relation between Instructor and OfficeAssignment
        [ForeignKey("instructor")]
        public int InstructorId { get; set; }
        public Instructor? instructor { get; set; }
    }
}
