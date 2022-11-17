using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoCompletaResultadoQueryHandler : IRequestHandler<ObterQuestaoCompletaResultadoQuery, QuestaoCompletaResultadoDto>
    {

        private readonly IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta;

        public ObterQuestaoCompletaResultadoQueryHandler(IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta)
        {
            this.repositorioQuestaoAlunoResposta = repositorioQuestaoAlunoResposta ?? throw new System.ArgumentNullException(nameof(repositorioQuestaoAlunoResposta));
        }

        public async Task<QuestaoCompletaResultadoDto> Handle(ObterQuestaoCompletaResultadoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoAlunoResposta.ObterResultadoQuestaoAsync(request.AlunoRa, request.ProvaId, request.QuestaoLegadoId);
        }
    }
}
