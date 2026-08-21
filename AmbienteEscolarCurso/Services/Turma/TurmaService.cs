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

        public TurmaModel CadastrarTurma(TurmaModel turmaModel)
        {
            try
            {
                if (!VerificaNomeTurma(turmaModel))
                {
                    return null;
                }

                _context.Turmas.Add(turmaModel);
                _context.SaveChanges();

                return turmaModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool VerificaNomeTurma(TurmaModel turmaModel)
        {
            var turma = _context.Turmas.FirstOrDefault(turma => turma.Descricao == turmaModel.Descricao);
            if(turma == null)
            {
                return true;
            }

            return false;
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
