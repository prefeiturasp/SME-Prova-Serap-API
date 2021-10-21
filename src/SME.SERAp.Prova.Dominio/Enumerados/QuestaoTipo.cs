using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum QuestaoTipo
    {
        [Display(Name = "Não cadastrado")]
        NaoCadastrado = 0,

        [Display(Name = "Múltipla escolha 4 alternativas")]
        MultiplaEscolha4Alternativas = 1,

        [Display(Name = "Múltipla escolha 5 alternativas")]
        MultiplaEscolha5Alternativas = 2,

        [Display(Name = "Resposta construída")]
        RespostaConstruida = 3,
    }
}