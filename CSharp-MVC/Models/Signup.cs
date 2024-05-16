using System.ComponentModel.DataAnnotations;

namespace CSharp_MVC.Models
{
    public class Signup
    {
        [Required(ErrorMessage = "Field must not be empty !")]
        [MinLength(6, ErrorMessage = "Account must contains at least 6 characters !")]
        [MaxLength(50, ErrorMessage = "Account must contains less than 50 characters !")]
        public string Account { get; set; } //Account
        [Required(ErrorMessage = "Field must not be empty !")]
        [MinLength(6, ErrorMessage = "Password must contains at least 6 characters !")]
        [MaxLength(50, ErrorMessage = "Password must contains less than 50 characters !")]
        public string Password { get; set; } //Password
        [Required(ErrorMessage = "Field must not be empty !")]
        public string Address { get; set; } //Address
        [Required(ErrorMessage = "Field must not be empty !")]
        public string Nationality { get; set; } //Nationality
        [Required(ErrorMessage = "Field must not be empty !")] 
        public string FullName { get; set; } //Full Name
        [Required(ErrorMessage = "Field must not be empty !")]
        public string Phone { get; set; } //Phone
    }
}
