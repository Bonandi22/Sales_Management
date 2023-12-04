using System.ComponentModel.DataAnnotations;

namespace Sales_Management.Models
{
    public class LoginModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Enter the user's email!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "The email provided is invalid!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Enter the user password!")]
        public string? Password { get; set; }

    }
}
