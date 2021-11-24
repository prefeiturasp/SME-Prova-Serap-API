using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class SincronizarQuestaoAlunoRespostaUseCase : ISincronizarQuestaoAlunoRespostaUseCase
    {
        private readonly IMediator mediator;

        public SincronizarQuestaoAlunoRespostaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(QuestaoAlunoRespostaSincronizarDto dto)
        {
            DateTime horaDataResposta = new(dto.DataHoraRespostaTicks);
            var provaStatus = await mediator.Send(new ObterProvaAlunoPorQuestaoIdRaQuery(dto.QuestaoId, dto.AlunoRa));

            if (provaStatus != null && provaStatus.Status == Dominio.ProvaStatus.Finalizado)
                throw new NegocioException("Esta prova já foi finalizada", 411);

            var questaoRespondida = await mediator.Send(new ObterQuestaoAlunoRespostaPorIdRaQuery(dto.QuestaoId, dto.AlunoRa));

            if (questaoRespondida == null)
            {
                return await mediator.Send(new IncluirQuestaoAlunoRespostaCommand(dto.QuestaoId, dto.AlunoRa, dto.AlternativaId, dto.Resposta, horaDataResposta, dto.TempoRespostaAluno ?? 0));
            }
            else if (questaoRespondida.CriadoEm > horaDataResposta)
            {
                return false;
            }
            else
            {
                questaoRespondida.Resposta = dto.Resposta;
                questaoRespondida.AlternativaId = dto.AlternativaId;
                questaoRespondida.TempoRespostaAluno += dto.TempoRespostaAluno ?? 0;
                questaoRespondida.CriadoEm = horaDataResposta;
                questaoRespondida.Visualizacoes += 1;

                return await mediator.Send(new AtualizarQuestaoAlunoRespostaCommand(questaoRespondida));
            }

        }
    }
}
