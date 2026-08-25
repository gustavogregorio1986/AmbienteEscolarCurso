using AmbienteEscolarCurso.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AmbienteEscolarCurso.Services.Historico
{
    public interface IHistoricoInterface
    {
        List<HistoricoModel> GerarHistorico(int idAluno);

        List<HistoricoModel> BuscarNotas(int idAluno); 

        List<SelectListItem> BuscarMaterias();

        HistoricoModel AtualizarNota(int idHistorico, string campo, string valor);

        bool ExcluirHistorico(int id);

        HistoricoModel AdicionarNota(int idHistorico, string campo, string valor);
    }
}
