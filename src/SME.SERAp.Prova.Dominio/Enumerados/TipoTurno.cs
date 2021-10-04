using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum TipoTurno
    {
        [Display(Name = "Manhã")]
        Manha = 1,
        [Display(Name = "Tarde")]
        Tarde = 2,
        [Display(Name = "Noturno")]
        Noturno = 3,
    }
}