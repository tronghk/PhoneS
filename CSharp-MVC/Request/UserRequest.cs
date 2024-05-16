using System.ComponentModel.DataAnnotations;

namespace CSharp_MVC.Request
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string Account { get; set;}
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string Password { get; set;}
    }
}
