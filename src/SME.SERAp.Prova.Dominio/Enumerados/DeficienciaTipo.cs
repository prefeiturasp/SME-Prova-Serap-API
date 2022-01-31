using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum DeficienciaTipo
    {
        [Display(Name = "CEGUEIRA")]
        CEGUEIRA = 11,

        [Display(Name = "BAIXA VISAO OU VISAO SUBNORMAL")]
        BAIXA_VISAO_OU_SUBNORMAL = 12
    }
}
