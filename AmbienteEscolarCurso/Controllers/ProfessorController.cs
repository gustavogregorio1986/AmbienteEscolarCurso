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

        public IActionResult ListarProfessores()
        {
            var professores = _professorInterface.BuscarProfessores();
            return View(professores);
        }
    }
}
