namespace SME.SERAp.Prova.Infra
{
    public class QuestaoAlternativaAlunoRespostaDto : DtoBase
    {
        public long QuestaoId { get; set; }
        public long AlternativaCorreta { get; set; }
        public long? AlternativaResposta { get; set; }
    }
}
