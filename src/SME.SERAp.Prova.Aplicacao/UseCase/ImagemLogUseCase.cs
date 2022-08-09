using System.Threading.Tasks;
using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.ImagemLog;
using SME.SERAp.Prova.Infra.Interfaces;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ImagemLogUseCase : IImagemLogUseCase
    {
        private readonly IServicoLog _servicoLog;

        public ImagemLogUseCase(IServicoLog servicoLog)
        {
            _servicoLog = servicoLog;
        }

        public Task Executar(ImagemLogDto dto)
        {
            _servicoLog.Registrar(LogNivel.Informacao, $"Imagem não exibida: Codigo do aluno {dto.Aluno}; Codigo da escola {dto.Escola}; Codigo da Prova {dto.Prova}; Html: {dto.Html}", string.Empty, string.Empty);
            return Task.CompletedTask;
        }
    }
}
