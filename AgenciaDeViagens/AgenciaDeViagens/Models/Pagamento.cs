using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeViagens.Models
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public string DescCompra { get; set; }

        [Required]
        public string DataDeCompra { get; set; }

        [Required]
        public int PaganteId { get; set; }
        [ForeignKey("PaganteId")]
        public Cliente Cliente { get; set; }
    }
}
