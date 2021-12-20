using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dominio.Enumerados
{
    public enum TipoDispositivo
    {

        [Display(Name = "Mobile")]
        Mobile = 1,
        [Display(Name = "Tablet")]
        Tablet = 2,
        [Display(Name = "Web")]
        Web = 3



    }
}
