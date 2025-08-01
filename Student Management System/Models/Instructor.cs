namespace Student_Management_System.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        //Navigation property
        public List<OfficeAssignment>? officeAssignments { get; set; }
    }
}
