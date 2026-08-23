using Microsoft.AspNetCore.Mvc;
using AmbienteEscolarCurso.Services.Materia;
using AmbienteEscolarCurso.Services.Professor;
using AmbienteEscolarCurso.Services.Turma;
using AmbienteEscolarCurso.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using AmbienteEscolarCurso.Dto.Professor;

namespace AmbienteEscolarCurso.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorInterface _professorInterface;
        private readonly ITurmaInterface _turmaInterface;
        private readonly IMateriaInterface _materiaInterface;

        public ProfessorController(IProfessorInterface professorInterface, ITurmaInterface turmaInterface, IMateriaInterface materiaInterface)
        {
            _professorInterface = professorInterface;
            _turmaInterface = turmaInterface;
            _materiaInterface = materiaInterface;
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

        [HttpGet]
        [Route("Professor/ProfessoresDaTurma/{idTurma}")]
        public IActionResult ProfessoresDaTurma(int idTurma)
        {
            var professores = _professorInterface.BuscarProfessorProTurma(idTurma);
            return Json(new {dados = professores});
        }

        [HttpGet]
        public IActionResult CadastrarProfessor()
        {
            // Aqui você usa um ViewModel para carregar as listas
            var vm = new ProfessorCriacaoDto
            {
                Materias = _materiaInterface.ListarMateria(),
                Turmas = _turmaInterface.ListarTurmas()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult CadastrarProfessor(ProfessorCriacaoDto dto)
        {
            // Remove erros de validação das listas auxiliares
            ModelState.Remove(nameof(dto.Materias));
            ModelState.Remove(nameof(dto.Turmas));

            if (ModelState.IsValid)
            {
                _professorInterface.CadastrarProfessor(dto);
                TempData["MensagemSucesso"] = "Professor cadastrado com sucesso!";
                return RedirectToAction("ListarProfessores");
            }

            dto.Materias = _materiaInterface.ListarMateria();
            dto.Turmas = _turmaInterface.ListarTurmas();
            return View(dto);
        }

    }
}
