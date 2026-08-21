using System.ComponentModel.DataAnnotations;

namespace AmbienteEscolarCurso.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A desrição é obrigatoria")]
        public string Descricao { get; set; }

        public string Turno { get; set; }

        public List<ProfessorModel>? Professores { get; set; }

        public string Modalidade { get; set; }

        public List<AlunoModel>? Alunos { get; set; }
    }
}
