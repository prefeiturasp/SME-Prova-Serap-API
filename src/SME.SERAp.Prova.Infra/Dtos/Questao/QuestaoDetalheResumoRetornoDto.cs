namespace SME.SERAp.Prova.Infra.Dtos
{
    public class QuestaoDetalheResumoRetornoDto
    {
        public QuestaoDetalheResumoRetornoDto(long provaId, long questaoId, long[] arquivosId, long[] alternativasId, long[] contextosProvaId, long[] audiosId, long[] videosId)
        {
            ProvaId = provaId;
            QuestaoId = questaoId;
            ArquivosId = arquivosId;
            AlternativasId = alternativasId;
            ContextosProvaId = contextosProvaId;
            AudiosId = audiosId;
            VideosId = videosId;
        }

        public long ProvaId { get; set; }
        public long QuestaoId { get; set; }
        public long[] ArquivosId { get; set; }
        public long[] AlternativasId { get; set; }
        public long[] ContextosProvaId { get; set; }
        public long[] AudiosId { get; set; }
        public long[] VideosId { get; set; }
    }
}
