using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra.Dtos.Questao;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestoesTaiAdministradoPorProvaAlunoQueryHandler : IRequestHandler<ObterQuestoesTaiAdministradoPorProvaAlunoQuery, IEnumerable<QuestaoTaiDto>>
    {
        private readonly IRepositorioQuestaoAlunoTai repositorioQuestaoAlunoTai;

        public ObterQuestoesTaiAdministradoPorProvaAlunoQueryHandler(IRepositorioQuestaoAlunoTai repositorioQuestaoAlunoTai)
        {
            this.repositorioQuestaoAlunoTai = repositorioQuestaoAlunoTai ?? throw new ArgumentNullException(nameof(repositorioQuestaoAlunoTai));
        }

        public async Task<IEnumerable<QuestaoTaiDto>> Handle(ObterQuestoesTaiAdministradoPorProvaAlunoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoAlunoTai.ObterQuestoesTaiPorProvaAlunoAsync(request.ProvaId, request.AlunoId);
        }
    }
}