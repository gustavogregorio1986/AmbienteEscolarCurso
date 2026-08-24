using AmbienteEscolarCurso.Services.Aluno;
using Microsoft.AspNetCore.Mvc;

namespace AmbienteEscolarCurso.Controllers
{
    public class AliunoController : Controller
    {
        private readonly IAlunoInterface _alunoInterface;

        public AliunoController(IAlunoInterface alunoInterface)
        {
            _alunoInterface = alunoInterface;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/Aluno/AlunosDaTurma/{idTurma}")]
        public IActionResult AlunosDaTurma(int idTurma)
        {
            var alunos = _alunoInterface.BuscarAlunosPorTurma(idTurma);
            return Json(new { dados = alunos });
        }
    }
}
