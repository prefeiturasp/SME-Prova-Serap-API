using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra.Dtos.Questao;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestoesTaiPorProvaAlunoQueryHandler : IRequestHandler<ObterQuestoesTaiPorProvaAlunoQuery, IEnumerable<QuestaoTaiDto>>
    {
        private readonly IRepositorioQuestaoAlunoTai _repositorioQuestaoAlunoTai;

        public ObterQuestoesTaiPorProvaAlunoQueryHandler(IRepositorioQuestaoAlunoTai repositorioQuestaoAlunoTai)
        {
            this._repositorioQuestaoAlunoTai = repositorioQuestaoAlunoTai ?? throw new ArgumentNullException(nameof(repositorioQuestaoAlunoTai));
        }

        public async Task<IEnumerable<QuestaoTaiDto>> Handle(ObterQuestoesTaiPorProvaAlunoQuery request, CancellationToken cancellationToken)
        {
            return await _repositorioQuestaoAlunoTai.ObterQuestoesTaiPorProvaAlunoAsync(request.ProvaId, request.AlunoId);
        }
    }
}