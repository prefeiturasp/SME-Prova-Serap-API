using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Infra
{
    public class RevalidaTokenDto : DtoBase
    {
  
        [Required(ErrorMessage = "É necessário informar o token.")]        
        public string Token { get; set; }
    }
}
