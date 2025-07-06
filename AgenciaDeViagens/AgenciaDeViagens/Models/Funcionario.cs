using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViagens.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Departamento { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
