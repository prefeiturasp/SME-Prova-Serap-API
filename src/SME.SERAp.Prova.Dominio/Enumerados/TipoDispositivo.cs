using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum TipoDispositivo
    {
        [Display(Name = "Não Cadastrado")]
        NaoCadastrado = 0,
        [Display(Name = "Mobile")]
        Mobile = 1,
        [Display(Name = "Tablet")]
        Tablet = 2,
        [Display(Name = "Web")]
        Web = 3
    }
}
