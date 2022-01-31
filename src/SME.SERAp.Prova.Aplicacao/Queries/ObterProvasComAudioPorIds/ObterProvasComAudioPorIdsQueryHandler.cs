using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasComAudioPorIdsQueryHandler : IRequestHandler<ObterProvasComAudioPorIdsQuery, long[]>
    {

        private readonly IRepositorioTipoDeficiencia repositorioTipoDeficiencia;

        public ObterProvasComAudioPorIdsQueryHandler(IRepositorioTipoDeficiencia repositorioTipoDeficiencia)
        {
            this.repositorioTipoDeficiencia = repositorioTipoDeficiencia ?? throw new System.ArgumentNullException(nameof(repositorioTipoDeficiencia));
        }

        public async Task<long[]> Handle(ObterProvasComAudioPorIdsQuery request, CancellationToken cancellationToken)
        {
            var provasComTipoDeficiencia = await repositorioTipoDeficiencia.ObterPorProvaIds(request.Ids);
            return provasComTipoDeficiencia.Where(a => a.DeficienciaCodigoEol == (int)DeficienciaTipo.BAIXA_VISAO_OU_SUBNORMAL || a.DeficienciaCodigoEol == (int)DeficienciaTipo.CEGUEIRA)
                .Select(a => a.ProvaId).ToArray();
        }
    }
}
