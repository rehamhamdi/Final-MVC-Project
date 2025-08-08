using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;

namespace Student_Management_System.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Address { get; set; }
    }
}
