using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao.Queries.VerificaStatusProvaFinalizada
{
    public class VerificaStatusProvaFinalizadoQueryHandler : IRequestHandler<VerificaStatusProvaFinalizadoQuery, bool>
    {
        public Task<bool> Handle(VerificaStatusProvaFinalizadoQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.Status is ProvaStatus.Finalizado or 
                ProvaStatus.FINALIZADA_AUTOMATICAMENTE_TEMPO or 
                ProvaStatus.FINALIZADA_AUTOMATICAMENTE_JOB or 
                ProvaStatus.FINALIZADA_OFFLINE);
        }
    }
}