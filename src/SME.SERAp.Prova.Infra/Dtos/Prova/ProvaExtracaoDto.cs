using System.Collections.Generic;

namespace SME.SERAp.Prova.Infra
{
    public class ProvaExtracaoDto : DtoBase
    {
        public long ProvaSerapId { get; set; }
        public long ExtracaoResultadoId { get; set; }
        public ProvaExtracaoDto()
        {

        }

    }
}