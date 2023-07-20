using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoProvaTaiUseCase : AbstractUseCase, IObterQuestaoProvaTaiUseCase
    {
        public ObterQuestaoProvaTaiUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<QuestaoCompletaDto> Executar(long provaId)
        {
            var dadosAlunoLogado = await mediator.Send(new ObterDadosAlunoLogadoQuery());
            var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, dadosAlunoLogado.Ra));

            if (provaStatus is not { Status: ProvaStatus.Iniciado })
                throw new NegocioException("Esta prova precisa ser iniciada.", 411);

            var questoesAluno = await mediator.Send(new ObterQuestaoTaiPorProvaAlunoQuery(provaId, dadosAlunoLogado.Ra));

            var ultimaQuestao = questoesAluno
                .Where(t => t.Ordem != 999)
                .OrderBy(t => t.Ordem)
                .LastOrDefault();
            
            if (ultimaQuestao == null)
                throw new NegocioException("Última questão não localizada.");

            var json = (await mediator.Send(new ObterQuestaoCompletaPorIdQuery(new[] { ultimaQuestao.Id }))).ToList();
            var jsonUltimaQuestao = json.FirstOrDefault();
            
            if (jsonUltimaQuestao == null)
                throw new NegocioException("Última questão não localizada (json).");

            var questaoCompleta = JsonSerializer.Deserialize<QuestaoCompletaDto>(jsonUltimaQuestao,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            questaoCompleta.Ordem = ultimaQuestao.Ordem == 0 ? 0 : ultimaQuestao.Ordem - 1;

            return questaoCompleta;
        }
    }
}
