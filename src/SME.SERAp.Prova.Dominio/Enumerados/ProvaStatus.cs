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
        FINALIZADA_AUTOMATICAMENTE_JOB = 5,

        [Display(Name = "Finalizado Automaticamente por Tempo")]
        FINALIZADA_AUTOMATICAMENTE_TEMPO = 6,

        [Display(Name = "Finalizado Offile")]
        FINALIZADA_OFFLINE = 7

    }
}