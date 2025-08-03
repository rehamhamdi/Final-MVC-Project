using Student_Management_System.Context;
using Student_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Validators
{
    public class UniqueInstructorAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ProjectDBContext db = new ProjectDBContext();
            var model = validationContext.ObjectInstance;
            var instructor = model as Instructor;
           // string name = (string)value;
            string name = instructor.Name;

            if (instructor.Id == 0)
            {
                var existingStudent = db.instructors.FirstOrDefault(s => s.Name == name);
                if (existingStudent != null)
                {
                    return new ValidationResult("This Instructor Already Exists");
                }
            }
            return ValidationResult.Success;
        }
    }
}
