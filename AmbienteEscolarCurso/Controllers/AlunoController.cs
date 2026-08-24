using AmbienteEscolarCurso.Models;
using AmbienteEscolarCurso.Services.Aluno;
using AmbienteEscolarCurso.Services.Turma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AmbienteEscolarCurso.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoInterface _alunoInterface;
        private readonly ITurmaInterface _turmaInterface;

        public AlunoController(IAlunoInterface alunoInterface, ITurmaInterface turmaInterface)
        {
            _alunoInterface = alunoInterface;
            _turmaInterface = turmaInterface;
        }

        public IActionResult Index()
        {
            BuscarTurmas();
            return View();
        }

        [HttpGet]
        public IActionResult ListarAlunos()
        {
            var alunos = _alunoInterface.BuscarAlunos();
            return View(alunos);
        }

        [HttpGet]
        public IActionResult CadastrarAluno()
        {
            BuscarTurmas();
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarAluno(AlunoModel alunoModel)
        {
            BuscarTurmas();
            return View();
        }

        [HttpGet]
        [Route("/Aluno/AlunosDaTurma/{idTurma}")]
        public IActionResult AlunosDaTurma(int idTurma)
        {
            var alunos = _alunoInterface.BuscarAlunosPorTurma(idTurma);
            return Json(new { dados = alunos });
        }

        public void BuscarTurmas()
        {
            var turmas = _turmaInterface.ListarTurmas();

            var listaTurma = new SelectList(turmas, "Id","Descricao");

            ViewBag.Turmas = listaTurma;
        }
    }
}
