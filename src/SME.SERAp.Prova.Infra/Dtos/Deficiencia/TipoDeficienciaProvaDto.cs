using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Infra
{
    public class TipoDeficienciaProvaDto
    {
        public TipoDeficienciaProvaDto()
        {

        }

        public long DeficienciaId { get; set; }
        public long ProvaId { get; set; }
        public int DeficienciaCodigoEol { get; set; }

    }
}
