﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum TipoTurno
    {
        [Display(Name = "Manhã")]
        Manha = 1,
        [Display(Name = "Intermediário")]
        Intermediario = 2,
        [Display(Name = "Tarde")]
        Tarde = 3,
        [Display(Name = "Vespertino")]
        Vespertino = 4,
        [Display(Name = "Noite")]
        Noite = 5,
        [Display(Name = "Integral")]
        Integral = 6,
    }
}