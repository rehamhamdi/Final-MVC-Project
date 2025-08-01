namespace Student_Management_System.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Navigation property
        public List<Student>? students { get; set; }
    }
}
