namespace SME.SERAp.Prova.Infra
{
    public class QuestaoOrdemDto
    {
        public QuestaoOrdemDto(long questaoId, long questaoLegadoId, AlternativaOrdemDto[] alternativas, int ordem)
        {
            QuestaoId = questaoId;
            QuestaoLegadoId = questaoLegadoId;
            Alternativas = alternativas;
            Ordem = ordem;
        }

        public long QuestaoId { get; set; }
        public long QuestaoLegadoId { get; set; }
        public AlternativaOrdemDto[] Alternativas { get; set; }
        public int Ordem { get; set; }
    }
}
