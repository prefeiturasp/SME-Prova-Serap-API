using System.Threading.Tasks;
using SME.SERAp.Prova.Infra.ImagemLog;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IImagemLogUseCase
    {
        Task Executar(ImagemLogDto dto);
    }
}
