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
        public string TextoDaPagina { get; set; }

        [Required]
        public List<string> ImagemUrl { get; set; }

        [Required]
        public int NumDeVendas { get; set; } = 0;

        public List<PeriodoIndisponivel> DatasOcupadas { get; set; }
    }
}
