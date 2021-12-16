using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum ProvaStatus
    {
        [Display(Name = "Não Iniciado")]
        NaoIniciado = 0,

        [Display(Name = "Iniciado")]
        Iniciado = 1,

        [Display(Name = "Finalizado")]
        Finalizado = 2,

        [Display(Name = "Pendente")]
        Pendente = 3,

        [Display(Name = "Em Revisão")]
        EmRevisao = 4,

        [Display(Name = "Finalizado Automaticamente")]
        FinalizadoAutomaticamente = 5,
    }
}