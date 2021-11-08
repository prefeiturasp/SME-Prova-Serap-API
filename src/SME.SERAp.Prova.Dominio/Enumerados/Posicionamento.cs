using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum Posicionamento
    {
        [Display(Name = "Não Cadastrado")]
        NaoCadastrado = 0,
        [Display(Name = "Direta")]
        Direita  = 1,
        [Display(Name = "Centro")]
        Centro = 2,
        [Display(Name = "Esquerda")]
        Esquerda = 3,
    }
}