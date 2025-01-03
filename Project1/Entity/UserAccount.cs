using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Project1.Entity
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(UserName), IsUnique = true)]
    public class UserAccount
    {
        [Key]

        public int id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "please choose gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "please enter date of birth")]
        [Display(Name = "DateofBirth")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50, ErrorMessage = "Max 100 characters allowed")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter the valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        //[DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        public string Password { get; set; }


        //[Compare("Password", ErrorMessage = "Please confirm your password")]
        //[DataType(DataType.Password)]
        //public string ConfirmPasword { get; set; }


        [Required(ErrorMessage = "please enter phonenumber")]
        [Display(Name = "Phonenumber")]
        [Phone]
        public string Phonenumber { get; set; }
        [Required]
        public string Hobbies { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }
    }
}
