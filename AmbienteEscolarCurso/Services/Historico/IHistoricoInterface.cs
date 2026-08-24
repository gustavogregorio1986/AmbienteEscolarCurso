using AmbienteEscolarCurso.Models;

namespace AmbienteEscolarCurso.Services.Historico
{
    public interface IHistoricoInterface
    {
        List<HistoricoModel> GerarHistorico(int idAluno);
    }
}
