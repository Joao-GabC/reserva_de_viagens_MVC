using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViagens.Models
{
    public class Pacote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double PrecoPorNoite { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string ImagemUrl { get; set; }
    }
}
