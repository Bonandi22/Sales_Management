using System.ComponentModel.DataAnnotations;

namespace Sales_Management.Models
{
    public class LoginModel
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string? Password { get; set; }

    }
}
