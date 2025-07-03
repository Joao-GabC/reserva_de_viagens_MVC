using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeViagens.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        public decimal PrecoTotal { get; set; }

        [Required]
        public int ReservanteId { get; set; }
        [ForeignKey("ReservanteId")]
        public Cliente Cliente { get; set; }
    }
}
