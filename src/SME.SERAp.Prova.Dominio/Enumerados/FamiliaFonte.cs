using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum FamiliaFonte
    {
        [Display(Name = "Poppins")]
        Poppins = 1,

        [Display(Name = "OpenDyslexic")]
        OpenDyslexic = 2,
    }
}