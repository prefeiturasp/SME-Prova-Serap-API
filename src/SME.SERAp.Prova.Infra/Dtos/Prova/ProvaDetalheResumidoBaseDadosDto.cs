namespace SME.SERAp.Prova.Infra
{
    public class ProvaDetalheResumidoBaseDadosDto : DtoBase
    {
        public long QuestaoId { get; set; }
        public long AlternativaId { get; set; }
        public long QuestaoArquivoId { get; set; }
        public long QuestaoArquivoTamanho { get; set; }
        public long AlternativaArquivoId { get; set; }
        public long AlternativaArquivoTamanho { get; set; }
    }
}
