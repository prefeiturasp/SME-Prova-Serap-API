namespace SME.SERAp.Prova.Dominio
{
    public class QuestaoArquivo : EntidadeBase
    {
        public long QuestaoId { get; set; }
        public long ArquivoId { get; set; }

        public QuestaoArquivo()
        {
        }

        public QuestaoArquivo(long questaoId, long arquivoId)
        {
            QuestaoId = questaoId;
            ArquivoId = arquivoId;
        }
    }
}