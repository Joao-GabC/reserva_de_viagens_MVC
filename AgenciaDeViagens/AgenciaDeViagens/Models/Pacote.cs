using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViagens.Models
{
    public class Pacote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal PrecoPorNoite { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string ImagemUrl { get; set; }

        [Required]
        public List<PeriodoIndisponivel> DatasOcupadas { get; set; }
    }
}
