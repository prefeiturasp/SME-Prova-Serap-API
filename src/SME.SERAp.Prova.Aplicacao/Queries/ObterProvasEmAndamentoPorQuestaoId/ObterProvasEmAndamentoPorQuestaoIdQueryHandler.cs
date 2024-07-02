using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasEmAndamentoPorQuestaoIdQueryHandler : IRequestHandler<ObterProvasEmAndamentoPorQuestaoIdQuery, IEnumerable<ProvaQuestaoDto>>
    {
        private readonly IRepositorioProva repositorioProva;

        public ObterProvasEmAndamentoPorQuestaoIdQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new ArgumentOutOfRangeException(nameof(repositorioProva)) ;
        }

        public async Task<IEnumerable<ProvaQuestaoDto>> Handle(ObterProvasEmAndamentoPorQuestaoIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterProvasEmAndamentoPorQuestaoIdAsync(request.QuestaoId);
        }
    }
}