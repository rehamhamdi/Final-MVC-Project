using Student_Management_System.Context;
using Student_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Validators
{
    public class UniqueCourseAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ProjectDBContext db = new ProjectDBContext();
            var model = validationContext.ObjectInstance;
            var course = model as Course;
            string name = (string)value;

            if (course.Id == 0)
            {
                var existingStudent = db.courses.FirstOrDefault(s => s.Name == name);
                if (existingStudent != null)
                {
                    return new ValidationResult("This Course Already Exists");
                }
            }
            return ValidationResult.Success;

        }
    }
}
