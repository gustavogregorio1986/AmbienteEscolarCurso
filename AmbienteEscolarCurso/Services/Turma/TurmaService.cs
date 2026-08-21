using AmbienteEscolarCurso.Data;
using AmbienteEscolarCurso.Models;
using Microsoft.EntityFrameworkCore;

namespace AmbienteEscolarCurso.Services.Turma
{
    public class TurmaService : ITurmaInterface
    {
        public AppDbContext _context;

        public TurmaService(AppDbContext context)
        {
            _context = context;
        }

        public List<TurmaModel> ListarTurmas()
        {
            try
            {
                var turmas = _context.Turmas.Include(a => a.Alunos).Include(p => p.Professores).ToList();

                return turmas;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
