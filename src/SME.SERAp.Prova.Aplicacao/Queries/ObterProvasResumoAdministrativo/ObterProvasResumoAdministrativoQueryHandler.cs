using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasResumoAdministrativoQueryHandler : IRequestHandler<ObterProvasResumoAdministrativoQuery, IEnumerable<QuestaoDetalheRetornoDto>>
    {
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterProvasResumoAdministrativoQueryHandler(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao;
        }

        public async Task<IEnumerable<QuestaoDetalheRetornoDto>> Handle(ObterProvasResumoAdministrativoQuery request, CancellationToken cancellationToken)
        {
            var questoes = await repositorioQuestao.ObterQuestoesPorProvaIdAsync(request.ProvaId);
            var retorno = new List<QuestaoDetalheRetornoDto>();

            if(questoes.Any())
            {
                foreach (var questao in questoes)
                    retorno.Add(new QuestaoDetalheRetornoDto(questao.Id, questao.TextoBase, questao.Enunciado, questao.Ordem, (int)questao.Tipo, questao.QuantidadeAlternativas));

                retorno = retorno.OrderBy(t => t.Ordem).ToList();
            }

            return retorno;
        }
    }
}
