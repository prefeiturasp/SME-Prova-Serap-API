namespace SME.SERAp.Prova.Infra.Test.Dtos.Autenticacao
{
    public class AutenticacaoUsuarioAdmDtoTest
    {
        [Fact]
        public void Deve_Criar_AutenticacaoUsuarioAdmDto_Com_Construtor_Parametros()
        {
            var guid = Guid.NewGuid();

            var dto = new AutenticacaoUsuarioAdmDto("admin.user", "Admin User", guid);

            Assert.Equal("admin.user", dto.Login);
            Assert.Equal("Admin User", dto.Nome);
            Assert.Equal(guid, dto.Perfil);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoUsuarioAdmDto_Com_Construtor_Padrao()
        {
            var guid = Guid.NewGuid();

            var dto = new AutenticacaoUsuarioAdmDto
            {
                Login = "login",
                Nome = "Nome",
                Perfil = guid
            };

            Assert.Equal("login", dto.Login);
            Assert.Equal("Nome", dto.Nome);
            Assert.Equal(guid, dto.Perfil);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoUsuarioAdmDto_Com_Valores_Default()
        {
            var dto = new AutenticacaoUsuarioAdmDto();

            Assert.Null(dto.Login);
            Assert.Null(dto.Nome);
            Assert.Equal(Guid.Empty, dto.Perfil);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoUsuarioAdmDto_Com_Login_Nulo()
        {
            var dto = new AutenticacaoUsuarioAdmDto(null, "Nome", Guid.NewGuid());

            Assert.Null(dto.Login);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoUsuarioAdmDto_Com_Nome_Nulo()
        {
            var dto = new AutenticacaoUsuarioAdmDto("login", null, Guid.NewGuid());

            Assert.Null(dto.Nome);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoUsuarioAdmDto_Com_Perfil_Guid_Empty()
        {
            var dto = new AutenticacaoUsuarioAdmDto("login", "Nome", Guid.Empty);

            Assert.Equal(Guid.Empty, dto.Perfil);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var dto = new AutenticacaoUsuarioAdmDto("login-original", "Nome Original", Guid.NewGuid());
            dto.Login = "login-novo";
            dto.Nome = "Nome Novo";

            Assert.Equal("login-novo", dto.Login);
            Assert.Equal("Nome Novo", dto.Nome);
        }
    }
}