using MediatR;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaAlunoUseCase : IObterProvaAlunoUseCase
    {
        private readonly IMediator mediator;

        public ObterProvaAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        
        public async Task<ProvaAlunoDto> Executar(long provaId)
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, alunoRa));

            return provaStatus != null ? new ProvaAlunoDto(provaStatus.Id, (int)provaStatus.Status) : null;
        }
    }
}
