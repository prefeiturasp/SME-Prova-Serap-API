using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum ExportacaoResultadoStatus
    {
        [Display(Name = "Não Iniciado")]
        NaoIniciado = 1,

        [Display(Name = "Aguardando execução")]
        Iniciado = 2,

        [Display(Name = "Processando")]
        Processando = 3,

        [Display(Name = "Finalizado")]
        Finalizado = 4,

        [Display(Name = "Erro")]
        Erro = 5,

        [Display(Name = "Solicitação cancelada")]
        Cancelado = 6
    }
}