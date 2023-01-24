using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
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
            var provas = await repositorioCache.ObterRedisAsync(CacheChave.ProvasAnosDatasEModalidades, async () => await repositorioProva.ObterAnosDatasEModalidadesAsync());
            if (provas != null && provas.Any())
            {
                return provas.Where(a =>
                    a.Inicio.Year == request.AnoLetivo &&
                    (!EhEjaCieja(a.Modalidade) && (int)a.Modalidade == request.Modalidade && a.Ano == request.Ano) ||
                    ((int)a.Modalidade == request.Modalidade && a.Ano == request.Ano && a.EtapaEja == request.EtapaEja));
            }

            return default;
        }

        private bool EhEjaCieja(Modalidade modalidade)
        {
            return modalidade == Modalidade.EJA || modalidade == Modalidade.CIEJA;
        }
    }
}
