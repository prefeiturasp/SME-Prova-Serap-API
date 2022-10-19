using System;

namespace SME.SERAp.Prova.Infra.Dtos
{
    public class DataHoraServidorDto: DtoBase
    {
        public DateTime DataHora { get; set; }
        public int Tolerancia { get; set; }
    }
}
