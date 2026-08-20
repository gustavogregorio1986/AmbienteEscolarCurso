using Microsoft.AspNetCore.Mvc;

namespace AmbienteEscolarCurso.Controllers
{
    public class TurmaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
