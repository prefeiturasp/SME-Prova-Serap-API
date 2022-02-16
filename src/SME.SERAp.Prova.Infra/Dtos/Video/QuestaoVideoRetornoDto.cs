
namespace SME.SERAp.Prova.Infra
{
    public class QuestaoVideoRetornoDto
    {
        public QuestaoVideoRetornoDto()
        {

        }

        public QuestaoVideoRetornoDto(long arquivoVideoId, long? arquivoThumbnailId, long? arquivoVideoConvertidoId)
        {
            ArquivoVideoId = arquivoVideoId;
            ArquivoThumbnailId = arquivoThumbnailId;
            ArquivoVideoConvertidoId = arquivoVideoConvertidoId;
        }

        public long ArquivoVideoId { get; set; }
        public long? ArquivoThumbnailId { get; set; }
        public long? ArquivoVideoConvertidoId { get; set; }

    }
}
