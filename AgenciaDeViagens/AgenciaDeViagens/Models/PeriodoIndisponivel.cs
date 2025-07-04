using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeViagens.Models
{
    public class PeriodoIndisponivel
    {
        [Key]
        public int Id { get; set; }


        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public int PacoteId { get; set; }
        [ForeignKey("PacoteId")]
        public Pacote Pacote { get; set; }
    }
}
