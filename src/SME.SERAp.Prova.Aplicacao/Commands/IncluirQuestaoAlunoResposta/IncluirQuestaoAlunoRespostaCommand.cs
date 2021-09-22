using MediatR;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirQuestaoAlunoRespostaCommand : IRequest<bool>
    {
        public IncluirQuestaoAlunoRespostaCommand(long questaoId, long alunoRa, long? alternativaId, string resposta, DateTime criadoEm)
        {
            QuestaoId = questaoId;
            AlunoRa = alunoRa;
            AlternativaId = alternativaId;
            Resposta = resposta;
            CriadoEm = criadoEm;
        }

        public long QuestaoId { get; set; }
        public long AlunoRa { get; set; }
        public long? AlternativaId { get; set; }
        public string Resposta { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
