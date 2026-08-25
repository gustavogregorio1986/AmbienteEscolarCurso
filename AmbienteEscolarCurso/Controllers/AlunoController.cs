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
        [Route("/Aluno/BuscarAlunoPorMatricula")]
        public IActionResult BuscarAlunoPorMatricula(int matricula)
        {
            var aluno = _alunoInterface.BuscarAlunoPorMatricula(matricula);
            return Json(new {dados = aluno});
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
            if (ModelState.IsValid)
            {
                var aluno = _alunoInterface.CadastrarAluno(alunoModel);

                if(aluno == null)
                {
                    TempData["MensagemError"] = "Ocorreu um erro na operação!";
                    BuscarTurmas();
                    return View(alunoModel);
                }

                TempData["MensagemSucesso"] = "Aluno foi cadastrado coim sucesso!";
                return RedirectToAction("ListarAlunos");
            }
            else
            {
                TempData["MensagemErro"] = "Campos Obrigatorios não foram preenchidos";
                BuscarTurmas();
                return View(alunoModel);
            }
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
