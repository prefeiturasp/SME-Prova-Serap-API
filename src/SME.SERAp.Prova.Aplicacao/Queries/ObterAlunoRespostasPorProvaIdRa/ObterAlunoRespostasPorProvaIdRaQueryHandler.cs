using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoRespostasPorProvaIdRaQueryHandler : IRequestHandler<ObterAlunoRespostasPorProvaIdRaQuery, IEnumerable<QuestaoAlunoResposta>>
    {
        private readonly IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta;

        public ObterAlunoRespostasPorProvaIdRaQueryHandler(IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta)
        {
            this.repositorioQuestaoAlunoResposta = repositorioQuestaoAlunoResposta ?? throw new System.ArgumentNullException(nameof(repositorioQuestaoAlunoResposta));
        }
        public async Task<IEnumerable<QuestaoAlunoResposta>> Handle(ObterAlunoRespostasPorProvaIdRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoAlunoResposta.ObterPorProvaIdERaAsync(request.ProvaId, request.AlunoRa);
        }
    }
}
