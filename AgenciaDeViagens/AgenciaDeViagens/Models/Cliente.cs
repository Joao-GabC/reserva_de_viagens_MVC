using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViagens.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string Passaporte { get; set; } = string.Empty;

        public ICollection<Pagamento> Pagamentos { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
