using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;

namespace Student_Management_System.Context
{
    public class ProjectDBContext :IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =DESKTOP-R23730E\\MSSQLSERVER1 ; Database= Student Management System ; Trusted_Connection=true; Encrypt=false");
           
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<OfficeAssignment> officeAssignments { get; set; }
        public DbSet<Attendance> attendances { get; set; }

    }
}
