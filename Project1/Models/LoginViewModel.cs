using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName or Email is required")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        [DisplayName("Username or Email")]
        public string UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 or min 5 characters allowed")]
        public string Password { get; set; }
    }
}
