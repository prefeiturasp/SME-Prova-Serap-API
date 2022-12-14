using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaTaiResultadoResumoUseCase : IObterProvaTaiResultadoResumoUseCase
    {
        private readonly IMediator mediator;

        public ObterProvaTaiResultadoResumoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<ProvaTaiResultadoDto>> Executar(long provaId)
        {
            var ra = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            var resumo = await mediator.Send(new ObterProvaTaiResultadoResumoQuery(provaId, ra));
            if (resumo != null && resumo.Any())
                return resumo.Where(r => !string.IsNullOrEmpty(r.AlternativaAluno));
            return default;
        }
    }
}
