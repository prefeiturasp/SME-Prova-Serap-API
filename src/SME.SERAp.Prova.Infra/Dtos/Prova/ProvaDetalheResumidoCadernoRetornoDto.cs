namespace SME.SERAp.Prova.Infra
{
    public class ProvaDetalheResumidoCadernoRetornoDto : DtoBase
    {
        public ProvaDetalheResumidoCadernoRetornoDto(long provaId, QuestaoOrdemDto[] questoes, long[] contextosProvaIds)
        {
            ProvaId = provaId;
            Questoes = questoes;
            ContextosProvaIds = contextosProvaIds;
        }

        public long ProvaId { get; set; }
        public QuestaoOrdemDto[] Questoes { get; set; }
        public long[] ContextosProvaIds {get;set;}
    }

    public class QuestaoOrdemDto
    {
        public QuestaoOrdemDto(long questaoId, long questaoLegadoId, int ordem)
        {
            QuestaoId = questaoId;
            QuestaoLegadoId = questaoLegadoId;
            Ordem = ordem;
        }

        public long QuestaoId { get; set; }
        public long QuestaoLegadoId { get; set; }
        public int Ordem { get; set; }
    }
}
