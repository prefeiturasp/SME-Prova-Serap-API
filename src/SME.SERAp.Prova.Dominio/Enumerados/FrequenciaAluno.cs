using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum FrequenciaAluno
    {
        [Display(Name = "Presente", ShortName = "P")]
        Presente = 1,

        [Display(Name = "Ausente", ShortName = "A")]
        Ausente = 2,

        [Display(Name = "Remoto", ShortName ="R")]
        Remoto = 3
    }
}
