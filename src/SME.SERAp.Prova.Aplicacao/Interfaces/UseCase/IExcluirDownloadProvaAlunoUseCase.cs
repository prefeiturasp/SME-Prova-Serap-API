using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IExcluirDownloadProvaAlunoUseCase
    {
        Task<bool> Executar(Guid[] ids);
    }
}
