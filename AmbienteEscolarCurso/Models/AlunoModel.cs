using System.Text.Json.Serialization;

namespace AmbienteEscolarCurso.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }

        public int Matricula { get; set; }

        public string Nome { get; set; }

        public string? Email { get; set; }

        public DateTime? DataNascimento { get; set; }

        public int TurmaId { get; set; }

        [JsonIgnore]
        public TurmaModel? Turma { get; set; }
    }
}
