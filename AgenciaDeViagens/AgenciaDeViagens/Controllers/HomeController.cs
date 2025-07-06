using AgenciaDeViagens.Data;
using AgenciaDeViagens.Models;
using AgenciaDeViagens.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;

namespace AgenciaDeViagens.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var pacotes = _context.Pacotes.ToList();
            var vm = new ReservarViewModel
            {
                Pacotes = pacotes
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
            var vm = new ReservarViewModel
            {
                Titulo = pacote.Titulo,
                Descricao = pacote.Descricao,
                ImagemUrl = pacote.ImagemUrl,
                TextoDaPagina = pacote.TextoDaPagina
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Pacote(int id, DateTime DataInicial, DateTime DataFinal)
        {
            var pacote = _context.Pacotes.FirstOrDefault(x => x.Id == id)!;
            var vm = new ReservarViewModel
            {
                Titulo = pacote.Titulo,
                Descricao = pacote.Descricao,
                ImagemUrl = pacote.ImagemUrl,
                TextoDaPagina = pacote.TextoDaPagina,
                DataInicial = DataInicial,
                DataFinal = DataFinal,
                PrecoPorNoite = pacote.PrecoPorNoite,
                
                PrecoTotal = (DataFinal - DataInicial).Days * pacote.PrecoPorNoite
            };

            return View(vm);
        }
    }
}
