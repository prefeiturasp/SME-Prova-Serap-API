using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum ExportacaoResultadoStatus
    {
        [Display(Name = "Não Iniciado")]
        NaoIniciado = 0,

        [Display(Name = "Iniciado")]
        Iniciado = 1,

        [Display(Name = "Processando")]
        Processando = 2,

        [Display(Name = "Finalizado")]
        Finalizado = 3,

        [Display(Name = "Erro")]
        Erro = 4
    }
}