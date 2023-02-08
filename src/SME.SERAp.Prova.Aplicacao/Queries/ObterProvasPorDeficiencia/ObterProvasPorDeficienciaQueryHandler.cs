using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasPorDeficienciaQueryHandler : IRequestHandler<ObterProvasPorDeficienciaQuery, long[]>
    {
        private readonly IRepositorioTipoDeficiencia repositorioTipoDeficiencia;

        public ObterProvasPorDeficienciaQueryHandler(IRepositorioTipoDeficiencia repositorioTipoDeficiencia)
        {
            this.repositorioTipoDeficiencia = repositorioTipoDeficiencia ?? throw new ArgumentNullException(nameof(repositorioTipoDeficiencia));
        }

        public async Task<long[]> Handle(ObterProvasPorDeficienciaQuery request, CancellationToken cancellationToken)
        {
            var provasComTipoDeficiencia = await repositorioTipoDeficiencia.ObterPorProvaIds(request.ProvasId);

            if (provasComTipoDeficiencia != null && provasComTipoDeficiencia.Any())
            {
                return provasComTipoDeficiencia
                    .Where(t => request.Deficiencias.Contains(t.DeficienciaCodigoEol))
                    .Select(s => s.ProvaId)
                    .ToArray();
            }

            return default;
        }
    }
}
