using System.Collections.Generic;

namespace SME.SERAp.Prova.Infra
{
    public class ProvaDetalheResumidoRetornoDto
    {
        public ProvaDetalheResumidoRetornoDto(long provaId, long[] questoesId, long[] arquivosId, long[] alternativasId, 
            long tamanhoTotalArquivos, long[] contextoProvaIds, long[] audiosId, long[] videosId)
        {
            ProvaId = provaId;
            QuestoesId = questoesId;
            ArquivosId = arquivosId;
            AlternativasId = alternativasId;
            TamanhoTotalArquivos = tamanhoTotalArquivos;
            ContextoProvaIds = contextoProvaIds;
            AudiosId = audiosId;
            VideosId = videosId;
        }

        public long ProvaId { get; set; }
        public long[] QuestoesId { get; set; }
        public long[] ArquivosId { get; set; }
        public long[] AudiosId { get; set; }
        public long[] AlternativasId { get; set; }
        public long[] ContextoProvaIds {get;set;}
        public long TamanhoTotalArquivos { get; set; }
        public long[] VideosId { get; set; }
    }
}
