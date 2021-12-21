using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ExportacaoResultadoIncluirCommandHandler : IRequestHandler<ExportacaoResultadoIncluirCommand, long>
    {
        private readonly IRepositorioExportacaoResultado repositorioExportacaoResultado;

        public ExportacaoResultadoIncluirCommandHandler(IRepositorioExportacaoResultado repositorioExportacaoResultado)
        {
            this.repositorioExportacaoResultado = repositorioExportacaoResultado ?? throw new ArgumentNullException(nameof(repositorioExportacaoResultado));
        }

        public async Task<long> Handle(ExportacaoResultadoIncluirCommand request, CancellationToken cancellationToken)
        {
            return await repositorioExportacaoResultado.IncluirAsync(request.ExportacaoResultado);
        }
    }
}