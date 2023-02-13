using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum ProvaFormatoTaiItem
    {
        [Display(Name = "Todos")]
        Todos,
        [Display(Name = "20")]
        Item_20 = 20,
        [Display(Name = "30")]
        Item_30 = 30,
        [Display(Name = "40")]
        Item_40 = 40,
        [Display(Name = "50")]
        Item_50 = 50
    }
}
