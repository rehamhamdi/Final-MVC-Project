using Student_Management_System.Context;
using Student_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Validators
{
    public class UniqueDepartmentAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ProjectDBContext db = new ProjectDBContext();
            var model = validationContext.ObjectInstance;
            var department = model as Department;
            string name = (string)value;

            if (department.Id == 0)
            {
                var existingStudent = db.departments.FirstOrDefault(s => s.Name == name);
                if (existingStudent != null)
                {
                    return new ValidationResult("This Department Already Exists");
                }
            }
            return ValidationResult.Success;
        }
    }
}
