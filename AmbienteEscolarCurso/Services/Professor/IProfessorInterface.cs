using AmbienteEscolarCurso.Dto.Professor;
using AmbienteEscolarCurso.Dto.Turma;
using AmbienteEscolarCurso.Models;

namespace AmbienteEscolarCurso.Services.Professor
{
    public interface IProfessorInterface
    {
        List<ProfessorModel> BuscarProfessores();

        ProfessorModel ObterProfessorComTurmaAluno(int id);

        List<MateriaModel> GetMaterias();

        void CadastrarProfessor(ProfessorCriacaoDto dto);
    }
}
