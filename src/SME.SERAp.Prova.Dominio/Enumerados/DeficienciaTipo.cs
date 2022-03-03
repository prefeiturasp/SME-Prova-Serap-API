using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum DeficienciaTipo
    {
        [Display(Name = "CEGUEIRA")]
        CEGUEIRA = 11,

        [Display(Name = "BAIXA VISAO OU VISAO SUBNORMAL")]
        BAIXA_VISAO_OU_SUBNORMAL = 12,

        [Display(Name = "SURDEZ LEVE/MODERADA")]
        SURDEZ_LEVE_MODERADA = 5,

        [Display(Name = "SURDEZ SEVERA/PROFUNDA")]
        SURDEZ_SEVERA_PROFUNDA = 6
    }
}
