using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasResumoAdministrativoQueryHandler : IRequestHandler<ObterProvasResumoAdministrativoQuery, IEnumerable<ProvaResumoAdministrativoRetornoDto>>
    {
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterProvasResumoAdministrativoQueryHandler(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao ?? throw new System.ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<IEnumerable<ProvaResumoAdministrativoRetornoDto>> Handle(ObterProvasResumoAdministrativoQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Caderno))
            {
                var questoes = await repositorioQuestao.ObterQuestoesPorProvaIdAsync(request.ProvaId);
                return PrepararRetorno(questoes);
            }
            else
            {
                var questoes = await repositorioQuestao.ObterQuestoesPorProvaIdCadernoAsync(request.ProvaId, request.Caderno);
                return PrepararRetorno(questoes);
            }
        }

        private static IEnumerable<ProvaResumoAdministrativoRetornoDto> PrepararRetorno(IEnumerable<Questao> questoes)
        {
            var retorno = new List<ProvaResumoAdministrativoRetornoDto>();
            if (questoes.Any())
            {
                foreach (var questao in questoes)
                    retorno.Add(new ProvaResumoAdministrativoRetornoDto(questao.Id, questao.TextoBase, questao.Enunciado, questao.Caderno, questao.Ordem));

                retorno = retorno.OrderBy(t => t.Ordem).ToList();
            }

            return retorno;
        }
    }
}
