using AgenciaDeViagens.Models;
using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViagens.ViewModel
{
    public class ReservarViewModel
    {
        //parte do pacote
        public int Id { get; set; }
        public string Titulo { get; set; }

        public decimal PrecoPorNoite { get; set; }

        public string Descricao { get; set; }

        public string TextoDaPagina { get; set; }
        public List<string> ImagemUrl { get; set; }

        public List<PeriodoIndisponivel> DatasOcupadas { get; set; }

        public List<Pacote> Pacotes { get; set; }

        //parte da reserva

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicial { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataFinal { get; set; }

        //parte do pagamento
        public decimal PrecoTotal { get; set; } = 0;
    }
}
