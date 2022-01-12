using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova
{
    public class AutenticacaoAdmDto
    {
        [Required(ErrorMessage = "É necessário informar login ou código Rf.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "É necessário informar o perfil.")]
        public string Perfil { get; set; }
    }
}
