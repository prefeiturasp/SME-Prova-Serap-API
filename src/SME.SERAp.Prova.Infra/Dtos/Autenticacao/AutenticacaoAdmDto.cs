using SME.SERAp.Prova.Infra;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova
{
    public class AutenticacaoAdmDto : DtoBase
    {
        [Required(ErrorMessage = "É necessário informar login ou código Rf.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "É necessário informar o perfil.")]
        public string Perfil { get; set; }

        [Required(ErrorMessage = "É necessário informar a chave api .")]

        public string ChaveApi { get; set; }

    }
}
