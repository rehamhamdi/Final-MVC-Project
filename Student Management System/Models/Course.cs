namespace Student_Management_System.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreditsHours { get; set; }
        //Navigation Properties
        public List<Enrollment>? enrollments { get; set; }
        public List<Attendance>? attendances { get; set; }

    }
}
