using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoAlternativaComCriadoEmTaiQueryHandler : IRequestHandler<ObterQuestaoAlternativaComCriadoEmTaiQuery, IEnumerable<QuestaoAlunoRespostaCriadoEmDto>>
    {
       
        private readonly IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta;

        public ObterQuestaoAlternativaComCriadoEmTaiQueryHandler(IRepositorioCache repositorioCache, IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta)
        {
            this.repositorioQuestaoAlunoResposta = repositorioQuestaoAlunoResposta ?? throw new ArgumentNullException(nameof(repositorioQuestaoAlunoResposta));
        }

        public async Task<IEnumerable<QuestaoAlunoRespostaCriadoEmDto>> Handle(ObterQuestaoAlternativaComCriadoEmTaiQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoAlunoResposta.ObterQuestaoAlternativaComCriadoEmTaiAsync(request.AlunoRa, request.ProvaId);
        }
    }
}
