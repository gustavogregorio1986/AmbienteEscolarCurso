using AmbienteEscolarCurso.Data;
using AmbienteEscolarCurso.Models;
using Microsoft.EntityFrameworkCore;

namespace AmbienteEscolarCurso.Services.Professor
{
    public class ProfessorService : IProfessorInterface
    {
        private readonly AppDbContext _context;

        public ProfessorService(AppDbContext context)
        {
            _context = context;
        }

        public List<ProfessorModel> BuscarProfessores()
        {
            try
            {
                var professores = _context.Professores.Include(t => t.Turmas).Include(m => m.Materia).ToList();
                return professores;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ProfessorModel ObterProfessorComTurmaAluno(int id)
        {
            try
            {
                var professorTurmaAlunos = _context.Professores
                                         .Where(p => p.Id == id)
                                         .Include(t => t.Turmas)
                                         .ThenInclude(a => a.Alunos)
                                         .FirstOrDefault();
                return professorTurmaAlunos;
            }
            catch
            {
                return null;
            }
        }
    }
}
