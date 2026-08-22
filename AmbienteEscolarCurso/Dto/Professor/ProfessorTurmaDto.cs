namespace AmbienteEscolarCurso.Dto.Professor
{
    namespace AmbienteEscolarCurso.Dto.Professor
    {
        public class ProfessorTurmaDto
        {
            public int ProfessoresId { get; set; }
            public int TurmasId { get; set; }

            // Opcional: se quiser exibir dados relacionados
            public string NomeProfessor { get; set; }
            public string NomeTurma { get; set; }
        }
    }

}
