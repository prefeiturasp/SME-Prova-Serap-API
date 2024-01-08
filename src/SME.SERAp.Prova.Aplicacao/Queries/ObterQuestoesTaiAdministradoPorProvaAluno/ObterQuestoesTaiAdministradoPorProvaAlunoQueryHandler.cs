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
        private readonly IRepositorioQuestaoAlunoAdministrado repositorioQuestaoAlunoAdministrado;

        public ObterQuestoesTaiAdministradoPorProvaAlunoQueryHandler(IRepositorioQuestaoAlunoAdministrado repositorioQuestaoAlunoAdministrado)
        {
            this.repositorioQuestaoAlunoAdministrado = repositorioQuestaoAlunoAdministrado ?? throw new ArgumentNullException(nameof(repositorioQuestaoAlunoAdministrado));
        }

        public async Task<IEnumerable<QuestaoTaiDto>> Handle(ObterQuestoesTaiAdministradoPorProvaAlunoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoAlunoAdministrado.ObterQuestoesTaiAdministradoPorProvaAlunoAsync(request.ProvaId, request.AlunoId);
        }
    }
}