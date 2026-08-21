using AmbienteEscolarCurso.Services.Turma;
using Microsoft.AspNetCore.Mvc;

namespace AmbienteEscolarCurso.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaInterface _turmaInterface;

        public TurmaController(ITurmaInterface turmaInterface)
        {
            _turmaInterface = turmaInterface;
        }

        public IActionResult ListarTurmas()
        {
            var turmas = _turmaInterface.ListarTurmas();

            return View(turmas);
        }
    }
}
