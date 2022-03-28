using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries.ObterQuestaoDetalhesResumidoAreaAdministrativo
{
    public class ObterQuestaoDetalhesResumidoAreaAdministrativoQueryHandle : IRequestHandler<ObterQuestaoDetalhesResumidoAreaAdministrativoQuery, IEnumerable<QuestaoDetalheResumoDadosDto>>
    {
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterQuestaoDetalhesResumidoAreaAdministrativoQueryHandle(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao ?? throw new System.ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<IEnumerable<QuestaoDetalheResumoDadosDto>> Handle(ObterQuestaoDetalhesResumidoAreaAdministrativoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestao.ObterDetalhesResumoPorIdAsync(request.ProvaId, request.QuestaoId);
        }
    }
}
