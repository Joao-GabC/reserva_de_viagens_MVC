using AgenciaDeViagens.Data;
using AgenciaDeViagens.ViewModel;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaDeViagens.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new DashboardViewModel
            {
                Pacotes = _context.Pacotes.ToList()
            };
            return View(vm);
        }
    }
}
