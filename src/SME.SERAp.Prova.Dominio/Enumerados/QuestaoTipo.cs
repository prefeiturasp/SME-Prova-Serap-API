using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum QuestaoTipo
    {
        [Display(Name = "Não Cadastrado")]
        NaoCadastrado = 0,

        [Display(Name = "Múltipla escolha 4 Alternativas")]
        MultiplaEscolha4Alternativas = 1,

        [Display(Name = "Múltipla escolha 5 Alternativas")]
        MultiplaEscolha5Alternativas = 2,

        [Display(Name = "Resposta construída")]
        RespostaConstruida = 3,
    }
}