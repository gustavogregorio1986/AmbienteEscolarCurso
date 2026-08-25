using AmbienteEscolarCurso.Services.Historico;
using AmbienteEscolarCurso.Services.Materia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AmbienteEscolarCurso.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly IHistoricoInterface _historicoInterface;

        public HistoricoController(IHistoricoInterface historicoInterface)
        {
            _historicoInterface = historicoInterface;
        }

        [HttpGet]
        [Route("/Historico/GerarHistorico/{idAluno}")]
        public IActionResult GerarHistorico(int idAluno)
        {
            var historico = _historicoInterface.GerarHistorico(idAluno);

            if(historico.Count() == 0)
            {
                TempData["MensagemErro"] = "Não exite notas lançadas paar esse aluno";
                return RedirectToAction("ListarAlunos", "Aluno");
            }

            if (historico == null)
            {
                TempData["MensagemErro"] = "Ocorreu um erro na operação";
                return RedirectToAction("ListarAlunos", "Aluno");
            }

            return View(historico);
        }

        [HttpGet]
        public IActionResult LancarNotas(int idAluno)
        {
            var notas = _historicoInterface.BuscarNotas(idAluno);
            ViewBag.Materias = _historicoInterface.BuscarMaterias();
            return View(notas);
        }

    }
}
