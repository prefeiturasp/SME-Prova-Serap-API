using MediatR;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterExportacaoResultadoStatusUseCase : IObterExportacaoResultadoStatusUseCase
    {
        private readonly IMediator mediator;

        public ObterExportacaoResultadoStatusUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<ExportacaoResultadoDto> Executar(long provaSerapId)
        {
            
            var resultado = await mediator.Send(new ObterExportacaoResultadoStatusPorProvaSerapIdQuery(provaSerapId));

            if (resultado != null)
            {
                return new ExportacaoResultadoDto(resultado.ProvaSerapId, resultado.NomeArquivo, resultado.CriadoEm, resultado.AtualizadoEm, resultado.Status);
            }
            else return null;
        }
    }
}
