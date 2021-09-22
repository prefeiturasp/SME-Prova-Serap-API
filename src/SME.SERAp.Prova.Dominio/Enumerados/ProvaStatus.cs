using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum ProvaStatus {
        [Display(Name = "Iniciado")]
        Iniciado = 1,

        [Display(Name = "Finalizado")]
        Finalizado = 2
    }
}