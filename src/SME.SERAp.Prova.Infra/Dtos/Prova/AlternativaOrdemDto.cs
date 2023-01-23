namespace SME.SERAp.Prova.Infra
{
    public class AlternativaOrdemDto
    {
        public AlternativaOrdemDto(long alternativaId, long alternativaLegadoId, int ordem)
        {
            AlternativaId = alternativaId;
            AlternativaLegadoId = alternativaLegadoId;
            Ordem = ordem;
        }

        public long AlternativaId { get; set; }
        public long AlternativaLegadoId { get; set; }
        public int Ordem { get; set; }
    }
}
