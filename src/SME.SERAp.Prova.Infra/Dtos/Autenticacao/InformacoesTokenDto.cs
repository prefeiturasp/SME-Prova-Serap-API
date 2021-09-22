namespace SME.SERAp.Prova.Infra
{
    public class InformacoesTokenDto
    {
        public InformacoesTokenDto(long ra, int ano, int tipoTurno)
        {
            Ra = ra;
            Ano = ano;
            TipoTurno = tipoTurno;
        }

        public long Ra { get; set; }
        public int Ano { get; set; }
        public int TipoTurno { get; set; }
    }
}
