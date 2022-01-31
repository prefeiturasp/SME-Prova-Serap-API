using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ExportacaoResultadoAtualizarCommand : IRequest<long>
    {
        public ExportacaoResultado ExportacaoResultado { get; set; }

        public ExportacaoResultadoAtualizarCommand(ExportacaoResultado exportacaoResultado)
        {
            ExportacaoResultado = exportacaoResultado;
        }
    }
}