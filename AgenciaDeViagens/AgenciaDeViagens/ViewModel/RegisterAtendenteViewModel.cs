using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViagens.ViewModel
{
    public class RegisterAtendenteViewModel
    {
        [Required(ErrorMessage = "Digite um nome!")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Escreva o seu departmento!")]
        public string Departamento { get; set; }
    }
}
