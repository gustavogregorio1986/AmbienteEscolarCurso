using AmbienteEscolarCurso.Data;
using AmbienteEscolarCurso.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AmbienteEscolarCurso.Services.Historico
{
    public class HistoricoService : IHistoricoInterface
    {
        private readonly AppDbContext _context;

        public HistoricoService(AppDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> BuscarMaterias()
        {
            return _context.Materias
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Descricao
                })
                .ToList();
        }

        public List<HistoricoModel> BuscarNotas(int idAluno)
        {
            try
            {
                var historico = _context.Historicos
                    .Include(h => h.Aluno)
                    .Include(h => h.Materia)
                    .Include(h => h.Aluno.Turma) // se precisar da turma também
                    .Where(h => h.AlunoId == idAluno) // LINQ filtrando pelo aluno
                    .ToList();

                return historico;
            }
            catch
            {
                return new List<HistoricoModel>();
            }
        }


        public List<HistoricoModel> GerarHistorico(int idAluno)
        {
            try
            {
                var historicos = _context.Historicos
                    .Include(a => a.Materia)
                    .Include(a => a.Aluno)
                    .ThenInclude(t => t.Turma).Where(h => h.AlunoId == idAluno)
                    .ToList();

                return historicos;

            }
            catch
            {
                return null;
            }
        }
    }
}
