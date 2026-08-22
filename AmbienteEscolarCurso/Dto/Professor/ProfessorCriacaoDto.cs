using AmbienteEscolarCurso.Models;
using System.ComponentModel.DataAnnotations;

public class ProfessorCriacaoDto
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Data de contratação é obrigatória")]
    public DateTime? DataContratacao { get; set; }

    [Required(ErrorMessage = "Selecione uma matéria")]
    public int MateriaId { get; set; }

    [Required(ErrorMessage = "Selecione ao menos uma turma")]
    public List<int> TurmasIds { get; set; } = new();

    // 🔹 NÃO coloque [Required] aqui!
    public IEnumerable<MateriaModel> Materias { get; set; }
    public IEnumerable<TurmaModel> Turmas { get; set; }
}