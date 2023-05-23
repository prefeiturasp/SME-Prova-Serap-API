using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUltimaExecucaoControleTipoPorTipoQuery : IRequest<ExecucaoControle>
    {
        public ObterUltimaExecucaoControleTipoPorTipoQuery(ExecucaoControleTipo tipo)
        {
            Tipo = tipo;
        }

        public ExecucaoControleTipo Tipo { get; set; }
    }
}
