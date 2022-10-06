using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasComVideoPorIdsQueryHandler : IRequestHandler<ObterProvasComVideoPorIdsQuery, long[]>
    {

        private readonly IRepositorioTipoDeficiencia repositorioTipoDeficiencia;

        public ObterProvasComVideoPorIdsQueryHandler(IRepositorioTipoDeficiencia repositorioTipoDeficiencia)
        {
            this.repositorioTipoDeficiencia = repositorioTipoDeficiencia ?? throw new System.ArgumentNullException(nameof(repositorioTipoDeficiencia));
        }

        public async Task<long[]> Handle(ObterProvasComVideoPorIdsQuery request, CancellationToken cancellationToken)
        {
            var provasComTipoDeficiencia = await repositorioTipoDeficiencia.ObterPorProvaIds(request.Ids);
            return provasComTipoDeficiencia
                .Where(a => 
                    a.DeficienciaCodigoEol == (int)DeficienciaTipo.SURDEZ_LEVE_MODERADA || 
                    a.DeficienciaCodigoEol == (int)DeficienciaTipo.SURDEZ_SEVERA_PROFUNDA)
                .Select(a => a.ProvaId).ToArray();
        }
    }
}
