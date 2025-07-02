using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViagens.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "A confirmação da senha é obrigatória")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem")]
        public string ConfirmPassword { get; set; }

        //------------------------------------------------------

        [Required(ErrorMessage = "Digite um nome!")]
        public string Nome { get; set; } = string.Empty;

        //email já é chamado

        [Required(ErrorMessage = "Digite um número de telefone válido!")]
        [MaxLength(11, ErrorMessage = "Esse número de telefone tem muitos caracteres! Lembre-se de usar apenas o DDD do estado.")]
        [MinLength(10, ErrorMessage = "Esse número de telefone tem poucos caracteres! Não falta nenhum número?")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite um CPF!")]
        [StringLength(11, ErrorMessage = "Esse CPF tem a quantidade incorreta de caracteres! Escreva somente os números, sem nenhum ponto ou traço.")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite um número de passaporte!")]
        [StringLength(8, ErrorMessage = "Esse número tem a quantidade incorreta de caracteres! Escreva somente a série com os números, sem nenhum espaço.")]
        public string Passaporte { get; set; } = string.Empty;
    }
}
