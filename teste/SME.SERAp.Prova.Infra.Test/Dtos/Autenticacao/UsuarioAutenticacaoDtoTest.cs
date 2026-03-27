namespace SME.SERAp.Prova.Infra.Test.Dtos.Autenticacao
{
    public class UsuarioAutenticacaoDtoTest
    {
        [Fact]
        public void Deve_Criar_UsuarioAutenticacaoDto_Com_Construtor_Parametros()
        {
            var expiracao = new DateTime(2024, 12, 31, 23, 59, 59);

            var dto = new UsuarioAutenticacaoDto("token-abc-123", expiracao);

            Assert.Equal("token-abc-123", dto.Token);
            Assert.Equal(expiracao, dto.DataHoraExpiracao);
        }

        [Fact]
        public void Deve_Criar_UsuarioAutenticacaoDto_Com_Construtor_Padrao()
        {
            var expiracao = new DateTime(2024, 6, 1);

            var dto = new UsuarioAutenticacaoDto
            {
                Token = "meu-token",
                DataHoraExpiracao = expiracao,
                UltimoLogin = DateTime.Today
            };

            Assert.Equal("meu-token", dto.Token);
            Assert.Equal(expiracao, dto.DataHoraExpiracao);
            Assert.Equal(DateTime.Today, dto.UltimoLogin);
        }

        [Fact]
        public void Deve_Criar_UsuarioAutenticacaoDto_Com_Valores_Default()
        {
            var dto = new UsuarioAutenticacaoDto();

            Assert.Null(dto.Token);
            Assert.Equal(default(DateTime), dto.DataHoraExpiracao);
            Assert.Null(dto.UltimoLogin);
        }

        [Fact]
        public void Deve_Criar_UsuarioAutenticacaoDto_Com_UltimoLogin_Nulo_Por_Padrao()
        {
            var dto = new UsuarioAutenticacaoDto("token", DateTime.Now);

            Assert.Null(dto.UltimoLogin);
        }

        [Fact]
        public void Deve_Atribuir_UltimoLogin_Apos_Criacao()
        {
            var dto = new UsuarioAutenticacaoDto("token", DateTime.Now);
            dto.UltimoLogin = new DateTime(2024, 1, 15);

            Assert.Equal(new DateTime(2024, 1, 15), dto.UltimoLogin);
        }

        [Fact]
        public void Deve_Criar_UsuarioAutenticacaoDto_Com_Token_Nulo()
        {
            var dto = new UsuarioAutenticacaoDto(null, DateTime.Now);

            Assert.Null(dto.Token);
        }

        [Fact]
        public void Deve_Criar_UsuarioAutenticacaoDto_Com_Token_Vazio()
        {
            var dto = new UsuarioAutenticacaoDto("", DateTime.Now);

            Assert.Equal("", dto.Token);
        }

        [Fact]
        public void Deve_Alterar_Token_Apos_Criacao()
        {
            var dto = new UsuarioAutenticacaoDto("token-original", DateTime.Now);
            dto.Token = "token-novo";

            Assert.Equal("token-novo", dto.Token);
        }

        [Fact]
        public void Deve_Criar_UsuarioAutenticacaoDto_Com_DataHoraExpiracao_Futura()
        {
            var expiracao = DateTime.Now.AddHours(8);
            var dto = new UsuarioAutenticacaoDto("token", expiracao);

            Assert.Equal(expiracao, dto.DataHoraExpiracao);
        }
    }
}