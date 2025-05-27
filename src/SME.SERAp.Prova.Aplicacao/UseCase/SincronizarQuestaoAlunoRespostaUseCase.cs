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
            foreach (var dto in listaAlunoResposta)
            {
                var provas = await mediator.Send(new ObterProvasEmAndamentoPorQuestaoIdQuery(dto.QuestaoId));

                foreach (var prova in provas)
                {
                    //-> Verifica se a prova é TAI ou BIB e se a questão é nula para executar o "continue"
                    if (await ValidarQuestaoNaoExisteProvaAluno(prova.ProvaId, dto.AlunoRa, dto.QuestaoId))
                        continue;
                    //-> Publica resposta
                    await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirRespostaAluno, dto));

                    var dtoAcompanhamento = new QuestaoAlunoRespostaAcompDto(0, dto.AlunoRa, dto.QuestaoId, dto.AlternativaId, dto.TempoRespostaAluno);
                    //-> Publica acompanhamento
                    await mediator.Send(new PublicarFilaSerapEstudanteAcompanhamentoCommand(RotasRabbit.AcompProvaAlunoRespostaTratar, dtoAcompanhamento));
                }
            }

            return true;
        }

        private async Task<bool> ValidarQuestaoNaoExisteProvaAluno(long provaId, long alunoRa, long questaoId)
        {
            var prova = await mediator.Send(new ObterProvaPorIdQuery(provaId));

            if (!prova.PossuiBIB && !prova.FormatoTai)
                return false;

            var questoesAlternativas = await mediator.Send(new ObterAlternativaAlunoRespostaQuery(provaId, alunoRa));
            var questao = questoesAlternativas.FirstOrDefault(c => c.QuestaoId == questaoId);
            return questao == null;
        }
    }
}