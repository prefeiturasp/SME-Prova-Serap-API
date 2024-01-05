using MediatR;
using Microsoft.IdentityModel.Tokens;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao.Queries.VerificaStatusProvaFinalizada
{
    public class VerificaStatusProvaFinalizadoQueryHandler : IRequestHandler<VerificaStatusProvaFinalizadoQuery, bool>
    {
        public Task<bool> Handle(VerificaStatusProvaFinalizadoQuery request, CancellationToken cancellationToken)
        {
            if (request.Status == ProvaStatus.Finalizado ||
               request.Status == ProvaStatus.FINALIZADA_AUTOMATICAMENTE_TEMPO ||
               request.Status == ProvaStatus.FINALIZADA_AUTOMATICAMENTE_JOB ||
                 request.Status == ProvaStatus.FINALIZADA_OFFLINE)
                return Task.FromResult(true);

            return Task.FromResult(false);
        }

       
    }
}