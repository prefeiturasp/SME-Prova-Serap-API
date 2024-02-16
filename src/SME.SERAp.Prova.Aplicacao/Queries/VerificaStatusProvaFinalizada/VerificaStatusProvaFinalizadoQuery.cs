using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries.VerificaStatusProvaFinalizada
{
    public class VerificaStatusProvaFinalizadoQuery : IRequest<bool>
    {
        public VerificaStatusProvaFinalizadoQuery(ProvaStatus  status)
        {
            Status = status;
        }

        public ProvaStatus Status { get; set; }
    }
}

