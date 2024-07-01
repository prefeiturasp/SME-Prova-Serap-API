using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> Executar(List<QuestaoAlunoRespostaSincronizarDto> listaAlunoResposta)
        {
            foreach(var dto in listaAlunoResposta)
            {
                var provas = await mediator.Send(new ObterProvasEmAndamentoPorQuestaoIdQuery(dto.QuestaoId));

                foreach (var prova in provas)
                {
                    var questoesAlternativas = await mediator.Send(new ObterAlternativaAlunoRespostaQuery(prova.ProvaId, dto.AlunoRa));

                    var questao = questoesAlternativas.FirstOrDefault(c => c.QuestaoId == dto.QuestaoId);
                    if (questao == null)
                        continue;
                    
                    await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirRespostaAluno, dto));
                    
                    //-> Acompanhamento
                    var dtoAcompanhamento = new QuestaoAlunoRespostaAcompDto(0, dto.AlunoRa, dto.QuestaoId, dto.AlternativaId, dto.TempoRespostaAluno);
                    await mediator.Send(new PublicarFilaSerapEstudanteAcompanhamentoCommand(RotasRabbit.AcompProvaAlunoRespostaTratar, dtoAcompanhamento));
                }
            }

            return true;
        }
    }
}
