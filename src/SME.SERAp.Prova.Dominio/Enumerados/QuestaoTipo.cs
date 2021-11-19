using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum QuestaoTipo
    {
        [Display(Name = "Não cadastrado")]
        NaoCadastrado = 0,

        [Display(Name = "Múltipla escolha")]
        MultiplaEscolha = 1,

        [Display(Name = "Resposta construída")]
        RespostaConstruida = 2,
    }
}