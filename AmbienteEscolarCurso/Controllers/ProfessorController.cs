using AmbienteEscolarCurso.Services.Professor;
using Microsoft.AspNetCore.Mvc;

namespace AmbienteEscolarCurso.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorInterface _professorInterface;

        public ProfessorController(IProfessorInterface professorInterface)
        {
            _professorInterface = professorInterface;
        }

        [HttpGet]
        public IActionResult ListarProfessores()
        {
            var professores = _professorInterface.BuscarProfessores();
            return View(professores);
        }

        [HttpGet("{id}")]
        public IActionResult DetalhesProfessor(int id)
        {
            var professor = _professorInterface.ObterProfessorComTurmaAluno(id);
            return View(professor);
        }
    }
}
