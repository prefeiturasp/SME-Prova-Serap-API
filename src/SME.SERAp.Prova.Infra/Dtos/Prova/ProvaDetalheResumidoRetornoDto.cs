namespace SME.SERAp.Prova.Infra
{
    public class ProvaDetalheResumidoRetornoDto
    {
        public ProvaDetalheResumidoRetornoDto(long provaId, long[] questoesId, long[] arquivosId, long[] alternativasId, long tamanhoTotalArquivos, long[] contextoProvaIds, long[] audioIds)
        {
            ProvaId = provaId;
            QuestoesId = questoesId;
            ArquivosId = arquivosId;
            AlternativasId = alternativasId;
            TamanhoTotalArquivos = tamanhoTotalArquivos;
            ContextoProvaIds = contextoProvaIds;
            AudioIds = audioIds;
        }

        public long ProvaId { get; set; }
        public long[] QuestoesId { get; set; }
        public long[] ArquivosId { get; set; }
        public long[] AudioIds { get; set; }
        public long[] AlternativasId { get; set; }
        public long[] ContextoProvaIds {get;set;}
        public long TamanhoTotalArquivos { get; set; }
    }
}
