using Microsoft.AspNetCore.Mvc;

namespace AmbienteEscolarCurso.Controllers
{
    public class HistoricoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
