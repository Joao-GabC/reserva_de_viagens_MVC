using AgenciaDeViagens.Models;
using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViagens.ViewModel
{
    public class AreaDoFuncionarioViewModel
    {
        public string Nome { get; set; }

        //parte do pacote novo
        [Display(Name = "Preço por noite")]
        public decimal PrecoPorNoite { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Texto da página")]
        public string TextoDaPagina { get; set; }

        public List<string> ImagemUrl { get; set; }

        public List<PeriodoIndisponivel> DatasOcupadas { get; set; }
    }
}
