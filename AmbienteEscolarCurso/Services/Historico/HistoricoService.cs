using AmbienteEscolarCurso.Data;
using AmbienteEscolarCurso.Models;
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
