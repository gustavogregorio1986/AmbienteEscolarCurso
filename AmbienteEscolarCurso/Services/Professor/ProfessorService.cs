using AmbienteEscolarCurso.Data;
using AmbienteEscolarCurso.Dto.Professor;
using AmbienteEscolarCurso.Dto.Professor.AmbienteEscolarCurso.Dto.Professor;
using AmbienteEscolarCurso.Models;
using Microsoft.AspNetCore.Mvc;
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

        public List<ProfessorModel> BuscarProfessorProTurma(int idTurma)
        {
            try
            {
                var professoresDaturma = _context.Turmas
                    .Where(t => t.Id == idTurma)
                    .SelectMany(t => t.Professores)
                    .Include(p => p.Materia)
                    .ToList();

                return professoresDaturma;
            }
            catch
            {
                return null;
            }
        }

        public void CadastrarProfessor(ProfessorCriacaoDto dto)
        {
            // Cria o objeto Professor
            var professor = new ProfessorModel
            {
                Nome = dto.Nome,
                Email = dto.Email,
                DataContratacao = dto.DataContratacao.Value,
                MateriaId = dto.MateriaId,
                Turmas = new List<TurmaModel>() // 🔹 Inicializa para evitar NullReferenceException
            };

            // Busca as turmas selecionadas
            var turmasSelecionadas = _context.Turmas
                .Where(t => dto.TurmasIds.Contains(t.Id))
                .ToList();

            // Adiciona as turmas ao professor
            foreach (var turma in turmasSelecionadas)
            {
                professor.Turmas.Add(turma);
            }

            // Salva no banco
            _context.Professores.Add(professor);
            _context.SaveChanges();
        }

        public List<MateriaModel> GetMaterias()
        {
            return _context.Materias.ToList();
        }

        public List<TurmaModel> GetTurmas()
        {
            return _context.Turmas.ToList();
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
