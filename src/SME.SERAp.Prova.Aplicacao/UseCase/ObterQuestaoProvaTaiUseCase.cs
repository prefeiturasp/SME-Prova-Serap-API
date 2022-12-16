using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoProvaTaiUseCase : AbstractUseCase, IObterQuestaoProvaTaiUseCase
    {
        public ObterQuestaoProvaTaiUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<string> Executar(long provaId)
        {
            var dadosAlunoLogado = await mediator.Send(new ObterDadosAlunoLogadoQuery());
            var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, dadosAlunoLogado.Ra));

            if (provaStatus == null || provaStatus.Status != ProvaStatus.Iniciado)
                throw new NegocioException($"Esta prova precisa ser iniciada.", 411);

            var questoesAluno = await mediator.Send(new ObterQuestaoTaiPorProvaAlunoQuery(provaId, dadosAlunoLogado.Ra));

            var ultimaQuestao = questoesAluno
                .Where(t => t.Ordem != 999)
                .OrderBy(t => t.Ordem)
                .LastOrDefault();

            var questaoCompleta = await mediator.Send(new ObterQuestaoCompletaPorIdQuery(new long[] { ultimaQuestao.Id }));

            return questaoCompleta.FirstOrDefault();
        }
    }
}
