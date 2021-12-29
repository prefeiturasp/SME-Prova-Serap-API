using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum TipoSituacao
    {
        [Display(Name = "Ativo")]
        Ativo = 1,
        [Display(Name = "Excluído")]
        Excluído = 3,
    }
}
