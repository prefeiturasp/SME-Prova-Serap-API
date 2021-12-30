using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ExportacaoResultadoIncluirCommand : IRequest<long>
    {
        public ExportacaoResultado ExportacaoResultado { get; set; }

        public ExportacaoResultadoIncluirCommand(ExportacaoResultado exportacaoResultado)
        {
            ExportacaoResultado = exportacaoResultado;
        }
    }
}