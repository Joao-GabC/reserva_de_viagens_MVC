using AgenciaDeViagens.Data;
using AgenciaDeViagens.Models;
using AgenciaDeViagens.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index(DateTime DataInicial, DateTime DataFinal)
        {
            /*
            var idPacotesIndisponiveis = _context.PeriodosIndisponiveis
                .Where(x => x.DataInicio <= DataInicial && x.DataFim >= DataFinal)
                .Select(x => x.PacoteId)
                .Distinct();
            */
            
            List<Pacote> pacotesFiltrados = _context.Pacotes
                .Include(p => p.DatasOcupadas)
                .Where(p => !p.DatasOcupadas.Any(d =>
                    d.DataInicio <= DataFinal && d.DataFim >= DataInicial
                ))
                .ToList();

            foreach (var pacote in pacotesFiltrados)
            {
                Console.WriteLine($"Pacote: {pacote.Titulo}, Períodos Ocupados: {pacote.DatasOcupadas.Count}");
            }

            return View(pacotesFiltrados);
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
                ImagemUrl = pacote.ImagemUrl
            };

            return View(vm);
        }
        /*
        [HttpPost]
        public IActionResult Pacote()
        {
            return
        }
        */
    }
}
