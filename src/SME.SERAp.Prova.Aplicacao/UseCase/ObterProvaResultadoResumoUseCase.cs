using MediatR;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ObterProvaResultadoResumoUseCase : IObterProvaResultadoResumoUseCase
    {
        private readonly IMediator mediator;

        public ObterProvaResultadoResumoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<ProvaResultadoDto> Executar(long provaId)
        {
            var ra = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            var proficiencia = await mediator.Send(new ObterProficienciaFinalPorProvaQuery(ra, provaId));
            var resumo = await mediator.Send(new ObterProvaResultadoResumoQuery(provaId, ra));

            var provaResultado = new ProvaResultadoDto
            {
                Proficiencia = proficiencia,
                Resumos = resumo
            };

            return provaResultado;
        }
    }
}
