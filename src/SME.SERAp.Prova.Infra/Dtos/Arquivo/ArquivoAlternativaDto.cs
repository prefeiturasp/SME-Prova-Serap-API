namespace SME.SERAp.Prova.Infra
{
    public class ArquivoAlternativaDto : DtoBase
    {
        public long AlternativaId { get; set; }
        public long Id { get; set; }
        public string Caminho { get; set; }
        public long TamanhoBytes { get; set; }
    }
}
