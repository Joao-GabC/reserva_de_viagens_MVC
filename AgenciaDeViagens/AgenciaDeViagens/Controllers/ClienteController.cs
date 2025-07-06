using AgenciaDeViagens.Data;
using AgenciaDeViagens.Models;
using AgenciaDeViagens.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AgenciaDeViagens.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email)!;
            Cliente clienteAtual = _context.Clientes.FirstOrDefault(x => x.Email == userEmail)!;

            return View(clienteAtual);
        }

        [HttpGet]
        public IActionResult HistoricoPagamentos()
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email)!;
            Cliente clienteAtual = _context.Clientes.FirstOrDefault(x => x.Email == userEmail)!;
            List<Pagamento> pagamentos = _context.Pagamentos.Where(x => x.Id == clienteAtual.Id).ToList();
            
            var vm = new ClienteDadosViewModel {
                ClienteNome = clienteAtual.Nome,
                Pagamentos = pagamentos
            };

            return View(vm);
        }
        [HttpGet]
        public IActionResult HistoricoReservas()
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email)!;
            Cliente clienteAtual = _context.Clientes.FirstOrDefault(x => x.Email == userEmail)!;
            List<Reserva> reservas = _context.Reservas.Where(x => x.Id == clienteAtual.Id).ToList();

            var vm = new ClienteDadosViewModel {
                ClienteNome = clienteAtual.Nome,
                Reservas = reservas
            };

            return View(vm);
        }
    }
}
