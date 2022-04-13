using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasPorAnoEModalidadeQueryHandler : IRequestHandler<ObterProvasPorAnoEModalidadeQuery, IEnumerable<ProvaAnoDto>>
    {
        private readonly IRepositorioProva repositorioProva;
        private readonly IRepositorioCache repositorioCache;

        public ObterProvasPorAnoEModalidadeQueryHandler(IRepositorioProva repositorioProva, IRepositorioCache repositorioCache)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
        }
        public async Task<IEnumerable<ProvaAnoDto>> Handle(ObterProvasPorAnoEModalidadeQuery request, CancellationToken cancellationToken)
        {
            var provas = await repositorioCache.ObterRedisAsync("pas", async () => await repositorioProva.ObterAnosDatasEModalidadesAsync());
            if (provas != null && provas.Any())
            {
                return provas.Where(a => (a.Modalidade != Dominio.Modalidade.EJA 
                                            && a.Modalidade != Dominio.Modalidade.CIEJA 
                                            && (int)a.Modalidade == request.Modalidade 
                                            && a.Ano == request.Ano)
                                         || ((int)a.Modalidade == request.Modalidade && a.Ano == request.Ano && a.EtapaEja == request.EtapaEja));
            }
            else return default;
        }
    }
}
