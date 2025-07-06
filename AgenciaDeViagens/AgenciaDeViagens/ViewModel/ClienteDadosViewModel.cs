using AgenciaDeViagens.Models;

namespace AgenciaDeViagens.ViewModel
{
    public class ClienteDadosViewModel
    {
        public int ClienteId { get; set; }

        public string ClienteNome { get; set; } = string.Empty;

        //-------------------------------------------------------

        public ICollection<Pagamento>? Pagamentos { get; set; }

        //-------------------------------------------------------

        public ICollection<Reserva>? Reservas { get; set; }
    }
}
