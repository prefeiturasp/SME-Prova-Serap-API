namespace SME.SERAp.Prova.Infra
{
    public class InformacoesTokenDto : DtoBase
    {
        public InformacoesTokenDto(long ra, string ano, int tipoTurno, int modalidade, string dispositivo)
        {
            Ra = ra;
            Ano = ano;
            TipoTurno = tipoTurno;
            Modalidade = modalidade;
            Dispositivo = dispositivo;
        }

        public long Ra { get; set; }
        public string Ano { get; set; }
        public int TipoTurno { get; set; }
        public int Modalidade { get; set; }
        public string Dispositivo { get; set; }
    }
}
