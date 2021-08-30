using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Infra
{
    public class AutenticacaoDto
    {
        [Required(ErrorMessage = "É necessário informar usuário ou código Rf.")]        
        [Range(99, long.MaxValue, ErrorMessage = "O código RA deve conter no mínimo 3 caracteres.")]
        public long Login { get; set; }

        [Required(ErrorMessage = "É necessário informar a senha.")]
        [MinLength(3, ErrorMessage = "A senha deve conter no mínimo 3 caracteres.")]
        public string Senha { get; set; }

        public string Dispositivo { get; set; }
    }
}
