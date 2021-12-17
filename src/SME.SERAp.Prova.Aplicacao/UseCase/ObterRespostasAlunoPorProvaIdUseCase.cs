using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterRespostasAlunoPorProvaIdUseCase : IObterRespostasAlunoPorProvaIdUseCase
    {
        private readonly IMediator mediator;

        public ObterRespostasAlunoPorProvaIdUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<IEnumerable<QuestaoAlunoRespostaConsultarDto>> Executar(long provaId)
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            var alunoRespostas = await mediator.Send(new ObterAlunoRespostasPorProvaIdRaQuery(provaId, alunoRa));

            if (alunoRespostas.Any())
            {
                var listaRetorno = alunoRespostas.Select(q =>
                    new QuestaoAlunoRespostaConsultarDto(q.AlternativaId, q.Resposta, q.CriadoEm, q.QuestaoId)
                );
                return listaRetorno;
            }
            else return null;
        }
    }
}
