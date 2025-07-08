using AgenciaDeViagens.Data;
using AgenciaDeViagens.Models;
using AgenciaDeViagens.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;
using System.Security.Claims;

namespace AgenciaDeViagens.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var pacotes = _context.Pacotes.ToList();
            var vm = new ReservarViewModel
            {
                Pacotes = pacotes,
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(DateOnly DataInicial, DateOnly DataFinal)
        {
            List<int> idPacotesindisponiveis = _context.PeriodosIndisponiveis
                .Where(p =>
                    (p.DataInicio <= DataInicial)
                )
                .Select(p => p.PacoteId)
                .Distinct()
                .ToList();


            List<Pacote> pacotesFiltrados = _context.Pacotes
                .Where(p => !idPacotesindisponiveis.Contains(p.Id))
                .ToList();

            var vm = new ReservarViewModel
            {
                Pacotes = pacotesFiltrados
            };

            TempData["debug"] = $"DataInicial: {DataInicial}, DataFinal: {DataFinal}";

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Pacote(int id)
        {
            var pacote = _context.Pacotes.FirstOrDefault(x => x.Id == id)!;
            var datasOcupadas = _context.PeriodosIndisponiveis.Where(d => d.PacoteId == pacote.Id).ToList();
            var vm = new ReservarViewModel
            {
                Id = pacote.Id,
                Titulo = pacote.Titulo,
                Descricao = pacote.Descricao,
                ImagemUrl = pacote.ImagemUrl,
                TextoDaPagina = pacote.TextoDaPagina,
                DatasOcupadas = datasOcupadas
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult CalcularPreco(int id, DateTime DataInicial, DateTime DataFinal)
        {
            var pacote = _context.Pacotes.FirstOrDefault(x => x.Id == id)!;
            var datasOcupadas = _context.PeriodosIndisponiveis.Where(d => d.PacoteId == pacote.Id).ToList();
            var vm = new ReservarViewModel
            {
                Id = pacote.Id,
                Titulo = pacote.Titulo,
                Descricao = pacote.Descricao,
                ImagemUrl = pacote.ImagemUrl,
                TextoDaPagina = pacote.TextoDaPagina,
                DataInicial = DataInicial,
                DataFinal = DataFinal,
                PrecoPorNoite = pacote.PrecoPorNoite,
                DatasOcupadas = datasOcupadas,
                
                PrecoTotal = (DataFinal - DataInicial).Days * pacote.PrecoPorNoite
            };

            return View("Pacote", vm);
        }
        [Authorize(Roles = "Cliente")]
        [HttpPost]
        public async Task<IActionResult> Pagar(int idPacote, DateTime DataInicial, DateTime DataFinal, decimal PrecoTotal)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email)!;

            var pacote = _context.Pacotes.FirstOrDefault(x => x.Id == idPacote)!;
            Cliente clienteAtual = _context.Clientes.FirstOrDefault(x => x.Email == userEmail)!;

            var dadosPagamento = new Pagamento
            {
                Preco = PrecoTotal,
                DescCompra = pacote.Descricao,
                DataDeCompra = DateTime.Today.ToString("dd-MM-yyyy"),
                PaganteId = clienteAtual.Id
            };
            var dadosReserva = new Reserva
            {
                Titulo = pacote.Titulo,
                DataInicio = DataInicial,
                DataFim = DataFinal,
                PrecoTotal = PrecoTotal,
                ReservanteId = clienteAtual.Id
            };
            pacote.NumDeVendas++;
            _context.Pagamentos.Add(dadosPagamento);
            _context.Reservas.Add(dadosReserva);
            _context.SaveChanges();

            //------------------------------------------------------------------------------------------

            var user = new IdentityUser { UserName = clienteAtual.Nome, Email = userEmail };

            await _emailSender.SendEmailAsync(user.Email, "Compra realizada!", $"<h1>{pacote.Titulo}<h1><br /><p>{pacote.Descricao}<p>");

            return RedirectToAction("Index"); //fazer toast pro pagamento aceito
        }
    }
}
