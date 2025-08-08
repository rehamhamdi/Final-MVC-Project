using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.View_Models
{
    public class RegisterUserVM
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
