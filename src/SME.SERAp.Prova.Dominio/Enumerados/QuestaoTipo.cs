using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum QuestaoTipo
    {
        [Display(Name = "Multipla escolha")]
        MultiplaEscolha = 0,

        [Display(Name = "Resposta construída")]
        RespostaConstruida = 1,
    }
}