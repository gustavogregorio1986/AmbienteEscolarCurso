namespace AmbienteEscolarCurso.Dto.Turma
{
    public class TurmaCriacaoDto
    {
        public int MateriaId { get; set; }
        public List<int> TurmasIds { get; set; } = new List<int>();

        public IEnumerable<TurmaCriacaoDto> Turmas { get; set; }
    }

}
