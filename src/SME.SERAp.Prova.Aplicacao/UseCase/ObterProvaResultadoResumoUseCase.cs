using MediatR;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;
using SME.SERAp.Prova.Infra.Exceptions;

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

            var prova = await mediator.Send(new ObterProvaPorIdQuery(provaId));
            if (prova == null)
                throw new NegocioException($"Prova {provaId} não localizada para obter o resumo do resultado do aluno.");
            
            string caderno = null;
            if (prova.PossuiBIB)
                caderno = await mediator.Send(new ObterCadernoAlunoPorProvaIdRaQuery(provaId, ra));
             
            var resumo = await mediator.Send(new ObterProvaResultadoResumoQuery(provaId, ra, caderno));

            var provaResultado = new ProvaResultadoDto
            {
                Proficiencia = proficiencia,
                Resumos = resumo
            };

            return provaResultado;
        }
    }
}
