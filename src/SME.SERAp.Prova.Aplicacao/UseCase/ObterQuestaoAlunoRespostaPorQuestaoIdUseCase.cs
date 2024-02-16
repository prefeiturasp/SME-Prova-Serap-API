using MediatR;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoAlunoRespostaPorQuestaoIdUseCase : IObterQuestaoAlunoRespostaPorQuestaoIdUseCase
    {
        private readonly IMediator mediator;

        public ObterQuestaoAlunoRespostaPorQuestaoIdUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<QuestaoAlunoRespostaConsultarDto> Executar(long questaoId)
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            var questaoAlunoResposta = await mediator.Send(new ObterQuestaoAlunoRespostaPorIdRaQuery(questaoId, alunoRa));

            if (questaoAlunoResposta != null)
            {
                return new QuestaoAlunoRespostaConsultarDto(questaoAlunoResposta.AlternativaId, questaoAlunoResposta.Resposta, questaoAlunoResposta.CriadoEm) ;
            }

            return null;
        }
    }
}
