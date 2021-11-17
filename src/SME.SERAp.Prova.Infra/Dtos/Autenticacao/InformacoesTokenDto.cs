namespace SME.SERAp.Prova.Infra
{
    public class InformacoesTokenDto
    {
        public InformacoesTokenDto(long ra, int ano, int tipoTurno, int modalidade)
        {
            Ra = ra;
            Ano = ano;
            TipoTurno = tipoTurno;
            Modalidade = modalidade;
        }

        public long Ra { get; set; }
        public int Ano { get; set; }
        public int TipoTurno { get; set; }
        public int Modalidade { get; set; }
    }
}
