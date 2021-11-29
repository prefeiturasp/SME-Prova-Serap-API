using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirQuestaoAlunoRespostaUseCase : IIncluirQuestaoAlunoRespostaUseCase
    {
        private readonly IMediator mediator;

        public IncluirQuestaoAlunoRespostaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar(QuestaoAlunoRespostaIncluirDto dto)
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            DateTime horaDataResposta = new(dto.DataHoraRespostaTicks);

            var questaoRespondida = await mediator.Send(new ObterQuestaoAlunoRespostaPorIdRaQuery(dto.QuestaoId, alunoRa));
                      
            if (questaoRespondida == null)
            {
                return await mediator.Send(new IncluirQuestaoAlunoRespostaCommand(dto.QuestaoId, alunoRa, dto.AlternativaId, dto.Resposta, horaDataResposta, dto.TempoRespostaAluno ?? 0));
            } else if (questaoRespondida.CriadoEm > horaDataResposta) 
            {
                return false;
            }else
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
