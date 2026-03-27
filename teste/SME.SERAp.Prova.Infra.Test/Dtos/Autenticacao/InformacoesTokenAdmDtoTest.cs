namespace SME.SERAp.Prova.Infra.Test.Dtos.Autenticacao
{
    public class InformacoesTokenAdmDtoTest
    {
        [Fact]
        public void Deve_Criar_InformacoesTokenAdmDto_Com_Construtor_Parametros()
        {
            var guid = Guid.NewGuid();

            var dto = new InformacoesTokenAdmDto("joao.silva", "João Silva", guid);

            Assert.Equal("joao.silva", dto.Login);
            Assert.Equal("João Silva", dto.Nome);
            Assert.Equal(guid, dto.Perfil);
        }

        [Fact]
        public void Deve_Criar_InformacoesTokenAdmDto_Com_Login_Nulo()
        {
            var dto = new InformacoesTokenAdmDto(null, "Nome", Guid.NewGuid());

            Assert.Null(dto.Login);
        }

        [Fact]
        public void Deve_Criar_InformacoesTokenAdmDto_Com_Nome_Nulo()
        {
            var dto = new InformacoesTokenAdmDto("login", null, Guid.NewGuid());

            Assert.Null(dto.Nome);
        }

        [Fact]
        public void Deve_Criar_InformacoesTokenAdmDto_Com_Perfil_Guid_Empty()
        {
            var dto = new InformacoesTokenAdmDto("login", "Nome", Guid.Empty);

            Assert.Equal(Guid.Empty, dto.Perfil);
        }

        [Fact]
        public void Deve_Criar_InformacoesTokenAdmDto_Com_Perfil_Especifico()
        {
            var guid = Guid.Parse("AAD9D772-41A3-E411-922D-782BCB3D218E");
            var dto = new InformacoesTokenAdmDto("login", "Nome", guid);

            Assert.Equal(guid, dto.Perfil);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var dto = new InformacoesTokenAdmDto("login-original", "Nome Original", Guid.NewGuid());
            dto.Login = "login-novo";
            dto.Nome = "Nome Novo";

            Assert.Equal("login-novo", dto.Login);
            Assert.Equal("Nome Novo", dto.Nome);
        }

        [Fact]
        public void Dois_Dtos_Com_Mesmo_Login_Devem_Ter_Perfis_Independentes()
        {
            var g1 = Guid.NewGuid();
            var g2 = Guid.NewGuid();
            var dto1 = new InformacoesTokenAdmDto("login", "Nome", g1);
            var dto2 = new InformacoesTokenAdmDto("login", "Nome", g2);

            Assert.Equal(dto1.Login, dto2.Login);
            Assert.NotEqual(dto1.Perfil, dto2.Perfil);
        }
    }
}