using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViagens.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite um nome!")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite um email!")]
        public string Email { get; set; } = string.Empty;

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
