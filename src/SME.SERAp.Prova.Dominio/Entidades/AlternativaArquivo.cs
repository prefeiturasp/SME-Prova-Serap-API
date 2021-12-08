namespace SME.SERAp.Prova.Dominio
{
    public class AlternativaArquivo : EntidadeBase
    {
        public AlternativaArquivo()
        {

        }
        public AlternativaArquivo(long arquivoId, long alternativaId
            )
        {
            ArquivoId = arquivoId;
            AlternativaId = alternativaId;
        }

        public long ArquivoId { get; set; }
        public long AlternativaId { get; set; }

    }
}
