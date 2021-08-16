namespace SME.SERAp.Prova.Infra
{
    public class InformacoesTokenDto
    {
        public InformacoesTokenDto(long ra, int ano)
        {
            Ra = ra;
            Ano = ano;
        }

        public long Ra { get; set; }
        public int Ano { get; set; }
    }
}
