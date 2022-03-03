using System;

namespace SME.SERAp.Prova.Dominio
{
    public class QuestaoVideo : EntidadeBase
    {
        public QuestaoVideo()
        {

        }

        public QuestaoVideo(long questaoId, long arquivoVideoId, long? arquivoThumbnailId, long? arquivoVideoConvertidoId)
        {
            QuestaoId = questaoId;
            ArquivoVideoId = arquivoVideoId;
            ArquivoThumbnailId = arquivoThumbnailId;
            ArquivoVideoConvertidoId = arquivoVideoConvertidoId;
            CriadoEm = AtualizadoEm = DateTime.Now;
        }

        public long QuestaoId { get; set; }
        public long ArquivoVideoId { get; set; }
        public long? ArquivoThumbnailId { get; set; }
        public long? ArquivoVideoConvertidoId { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
