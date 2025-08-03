using Student_Management_System.Context;
using Student_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Validators
{
    public class UniqueStudentAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ProjectDBContext db = new ProjectDBContext();
            var model = validationContext.ObjectInstance;
            var student = model as Student;
            string name = (string)value;
            
            if (student.Id == 0)
            {
                var existingStudent = db.students.FirstOrDefault(s => s.Name == name);
                if (existingStudent != null)
                {
                    return new ValidationResult("This Student Already Exists");
                }
            }
            return ValidationResult.Success;

        }
    }
}
