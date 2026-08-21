using AmbienteEscolarCurso.Models;
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

        [HttpGet]
        public IActionResult ListarTurmas()
        {
            var turmas = _turmaInterface.ListarTurmas();

            return View(turmas);
        }

        [HttpGet]
        public IActionResult CadastrarTurma()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarTurma(TurmaModel turma)
        {
            return View();  
        }
    }
}
