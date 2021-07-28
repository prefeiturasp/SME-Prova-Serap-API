namespace SME.SERAp.Prova.Infra
{
    public class UsuarioAutenticacaoDto
    {
        public UsuarioAutenticacaoDto()
        {

        }
        public UsuarioAutenticacaoDto(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
