using AmbienteEscolarCurso.Models;

namespace AmbienteEscolarCurso.Services.Professor
{
    public interface IProfessorInterface
    {
        List<ProfessorModel> BuscarProfessores();

        ProfessorModel ObterProfessorComTurmaAluno(int id);
    }
}
