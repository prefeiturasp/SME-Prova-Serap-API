using System;

namespace SME.SERAp.Prova.Infra
{
    public class UsuarioAutenticacaoDto : DtoBase
    {
        public UsuarioAutenticacaoDto()
        {

        }
        public UsuarioAutenticacaoDto(string token, DateTime dataHoraExpiracao)
        {
            Token = token;
            DataHoraExpiracao = dataHoraExpiracao;
        }

        public string Token { get; set; }
        public DateTime DataHoraExpiracao { get; set; }
        public DateTime? UltimoLogin { get; set; }
    }
}
