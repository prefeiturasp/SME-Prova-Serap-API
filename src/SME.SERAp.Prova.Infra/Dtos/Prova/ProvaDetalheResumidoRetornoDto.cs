namespace SME.SERAp.Prova.Infra
{
    public class ProvaDetalheResumidoRetornoDto
    {
        public ProvaDetalheResumidoRetornoDto(long provaId, long[] questoesId, long[] arquivosId, long[] alternativasId, long tamanhoTotalArquivos)
        {
            ProvaId = provaId;
            QuestoesId = questoesId;
            ArquivosId = arquivosId;
            AlternativasId = alternativasId;
            TamanhoTotalArquivos = tamanhoTotalArquivos;
        }

        public long ProvaId { get; set; }
        public long[] QuestoesId { get; set; }
        public long[] ArquivosId { get; set; }
        public long[] AlternativasId { get; set; }
        public long TamanhoTotalArquivos { get; set; }
    }
}
