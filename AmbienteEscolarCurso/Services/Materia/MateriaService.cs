using AmbienteEscolarCurso.Data;
using AmbienteEscolarCurso.Models;
using Microsoft.EntityFrameworkCore;

namespace AmbienteEscolarCurso.Services.Materia
{
    public class MateriaService : IMateriaInterface
    {
        private readonly AppDbContext _context;

        public MateriaService(AppDbContext context)
        {
            _context = context;
        }

        public List<MateriaModel> ListarMateria()
        {
            try
            {
                var materias = _context.Materias.ToList();
                return materias;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
