using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao.Queries
{
    public class ObterQuestaoDetalhesResumidoAreaAdministrativoQuery : IRequest<IEnumerable<QuestaoDetalheResumoDadosDto>>
    {
        public ObterQuestaoDetalhesResumidoAreaAdministrativoQuery(long provaId, long questaoId)
        {
            ProvaId = provaId;
            QuestaoId = questaoId;
        }

        public long ProvaId { get; set; }
        public long QuestaoId { get; set; }
    }
}
