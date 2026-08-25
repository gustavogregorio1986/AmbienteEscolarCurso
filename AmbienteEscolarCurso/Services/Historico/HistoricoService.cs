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

        public HistoricoModel AtualizarNota(int idHistorico, string campo, string valor)
        {
            try
            {
                var historico = _context.Historicos
                    .Include(m => m.Materia)
                    .Include(a => a.Aluno)
                    .Where(h => h.Id == idHistorico)
                    .FirstOrDefault();

                if(historico == null) return null;

                switch (campo) {
                    case "Nota1":historico.Nota1 = Double.Parse(valor);break;
                    case "Nota2": historico.Nota2 = Double.Parse(valor); break;
                    case "Nota3": historico.Nota3 = Double.Parse(valor); break;
                    case "Nota4": historico.Nota4 = Double.Parse(valor); break;
                }

                historico.Media = (historico.Nota1 + historico.Nota2 + historico.Nota3 + historico.Nota4) / 4;

                _context.SaveChanges();

                return historico;
            }
            catch
            {
                return null;
            }
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

        public bool ExcluirHistorico(int id)
        {
            var historico = _context.Historicos.FirstOrDefault(h => h.Id == id);
            if (historico == null) return false;

            _context.Historicos.Remove(historico);
            _context.SaveChanges();
            return true;
        }

        public HistoricoModel AdicionarNota(int idHistorico, string campo, string valor)
        {
            var historico = _context.Historicos
                .Include(m => m.Materia)
                .Include(a => a.Aluno)
                .FirstOrDefault(h => h.Id == idHistorico);

            if (historico == null) return null;

            if (double.TryParse(valor, out var nota))
            {
                switch (campo)
                {
                    case "Nota1": historico.Nota1 = nota; break;
                    case "Nota2": historico.Nota2 = nota; break;
                    case "Nota3": historico.Nota3 = nota; break;
                    case "Nota4": historico.Nota4 = nota; break;
                }

                historico.Media = (historico.Nota1 + historico.Nota2 + historico.Nota3 + historico.Nota4) / 4;
                _context.SaveChanges();
            }

            return historico;
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
