using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Infra
{
    public class AutenticacaoDto
    {
        [Required(ErrorMessage = "É necessário informar usuário ou código Rf.")]
        [MinLength(3, ErrorMessage = "O usuário ou código Rf deve conter no mínimo 3 caracteres.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "É necessário informar a senha.")]
        [MinLength(3, ErrorMessage = "A senha deve conter no mínimo 3 caracteres.")]
        public string Senha { get; set; }
    }
}
