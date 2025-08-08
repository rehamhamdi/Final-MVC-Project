using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.View_Models
{
    public class LoginUserVM
    {
        public string username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }

    }
}
