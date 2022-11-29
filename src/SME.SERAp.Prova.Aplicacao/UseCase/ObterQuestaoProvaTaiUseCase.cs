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

            var ultimaQuestaoIdTaiAluno = await mediator.Send(new ObterUltimaQuestaoTaiPorProvaAlunoQuery(provaId, dadosAlunoLogado.Ra));
            var questaoCompleta = await mediator.Send(new ObterQuestaoCompletaPorIdQuery(new long[] { ultimaQuestaoIdTaiAluno }));

            return questaoCompleta.FirstOrDefault();
        }
    }
}
