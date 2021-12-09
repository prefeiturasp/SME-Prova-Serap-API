using System;

namespace SME.SERAp.Prova.Infra
{
    public class QuestaoAlunoRespostaConsultarDto
    {
        public QuestaoAlunoRespostaConsultarDto(long? alternativaId, string resposta, DateTime dataHoraResposta)
        {
            AlternativaId = alternativaId;
            Resposta = resposta;
            DataHoraResposta = dataHoraResposta;
        }

        public QuestaoAlunoRespostaConsultarDto(long? alternativaId, string resposta, DateTime dataHoraResposta, long questaoId)
        {
            AlternativaId = alternativaId;
            Resposta = resposta;
            DataHoraResposta = dataHoraResposta;
            QuestaoId = questaoId;
        }

        public long QuestaoId { get; set; }
        public long? AlternativaId { get; set; }
        public string Resposta { get; set; }
        public DateTime DataHoraResposta { get; set; }
    }
}
