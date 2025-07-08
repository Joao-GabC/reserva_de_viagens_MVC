using AgenciaDeViagens.Data;
using AgenciaDeViagens.Models;
using AgenciaDeViagens.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AgenciaDeViagens.Controllers
{
    [Authorize(Roles = "Atendente, Admin")]
    public class FuncionarioController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new AreaDoFuncionarioViewModel { };
            if(User.IsInRole("Atendente"))
            {
                string staffEmail = User.FindFirstValue(ClaimTypes.Email)!;
                string staffNome = _context.Funcionarios.FirstOrDefault(x => x.Email == staffEmail)!.Nome;

                vm = new AreaDoFuncionarioViewModel
                {
                    Nome = staffNome
                };
            }
            else
            {
                vm = new AreaDoFuncionarioViewModel
                {
                    Nome = "Admin"
                };
            }

                return View(vm);
        }
        //action chamada dentro do index
        [HttpPost]
        public async Task<IActionResult> AdicionarPacote(List<IFormFile> imagens, AreaDoFuncionarioViewModel vModel, DateOnly DataInicial, DateOnly DataFinal) //model da página é a viewmodel AreaDoFuncionarioViewModel
        {
            var pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
            Directory.CreateDirectory(pasta);

            List<string> novasImagens = new List<string>();
            if (imagens != null && imagens.Count > 0)
            {
                foreach (var imagem in imagens)
                {
                    var nomeArquivo = Path.GetFileName(imagem.FileName);
                    var caminhoFisico = Path.Combine(pasta, nomeArquivo); // Caminho real no disco
                    var caminhoWeb = $"/img/{nomeArquivo}"; // Caminho para uso no HTML

                    using (var caminhoFoto = new FileStream(caminhoFisico, FileMode.Create))
                    {
                        imagem.CopyTo(caminhoFoto);
                    }

                    novasImagens.Add(caminhoWeb); // Este vai para o banco ou modelo
                }
            }

            /*
            if (_context.Pacotes.First(p => p.Titulo == vModel.Titulo) != null)
            {
                fazer toaster de erro falando que já existe um pacote com esse título
                return View(vModel);
            }
            */

            var pacoteNovo = new Pacote
            {
                Titulo = vModel.Titulo,
                PrecoPorNoite = vModel.PrecoPorNoite,
                Descricao = vModel.Descricao,
                TextoDaPagina = vModel.TextoDaPagina,
                ImagemUrl = novasImagens
            };
            _context.Pacotes.Add(pacoteNovo);
            _context.SaveChanges();

            if (!(DataFinal == default(DateOnly) || DataInicial == default(DateOnly)))
            {
                var periodoIndisponivelPacote = new PeriodoIndisponivel
                {
                    DataInicio = DataInicial,
                    DataFim = DataFinal,
                    PacoteId = pacoteNovo.Id
                };
                _context.PeriodosIndisponiveis.Add(periodoIndisponivelPacote);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
