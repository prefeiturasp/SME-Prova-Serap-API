namespace SME.SERAp.Prova.Infra
{
    public class QuestaoAlunoRespostaConsultarDto
    {
        public QuestaoAlunoRespostaConsultarDto(long? alternativaId, string resposta)
        {
            AlternativaId = alternativaId;
            Resposta = resposta;
        }

        public long? AlternativaId { get; set; }
        public string Resposta { get; set; }
    }
}
