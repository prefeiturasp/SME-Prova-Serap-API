using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUltimaExecucaoControleTipoPorTipoQueryHandler : IRequestHandler<ObterUltimaExecucaoControleTipoPorTipoQuery, ExecucaoControle>
    {
        private readonly IRepositorioExecucaoControle repositorioExecucaoControle;

        public ObterUltimaExecucaoControleTipoPorTipoQueryHandler(IRepositorioExecucaoControle repositorioExecucaoControle)
        {
            this.repositorioExecucaoControle = repositorioExecucaoControle ?? throw new System.ArgumentNullException(nameof(repositorioExecucaoControle));
        }
        public async Task<ExecucaoControle> Handle(ObterUltimaExecucaoControleTipoPorTipoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioExecucaoControle.ObterUltimaExecucaoPorTipoAsync(request.Tipo);
        }
    }
}
