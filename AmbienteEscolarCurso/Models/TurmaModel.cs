namespace AmbienteEscolarCurso.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Turno { get; set; }

        public List<ProfessorModel> Professores { get; set; }

        public List<AlunoModel> Alunos { get; set; }
    }
}
