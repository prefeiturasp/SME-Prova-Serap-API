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

            QuestaoAlunoRespostaSincronizarDto mensagem = new()
            {
                AlunoRa = alunoRa,
                QuestaoId = dto.QuestaoId,
                AlternativaId = dto.AlternativaId,
                Resposta = dto.Resposta,
                DataHoraRespostaTicks = dto.DataHoraRespostaTicks,
                TempoRespostaAluno = dto.TempoRespostaAluno,
            };

            return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirRespostaAluno, mensagem));
        }
    }
}
