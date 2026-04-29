using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Github
{
    public class VersaoGitHubRetornoDtoTest
    {
        [Fact]
        public void Deve_Criar_VersaoGitHubRetornoDto_Com_Propriedade_Padrao()
        {
            var dto = new VersaoGitHubRetornoDto();

            Assert.Null(dto.Name);
        }

        [Fact]
        public void Deve_Atribuir_Name_Corretamente()
        {
            var dto = new VersaoGitHubRetornoDto { Name = "v1.0.0" };

            Assert.Equal("v1.0.0", dto.Name);
        }

        [Fact]
        public void Deve_Aceitar_Name_Nulo()
        {
            var dto = new VersaoGitHubRetornoDto { Name = null };

            Assert.Null(dto.Name);
        }

        [Fact]
        public void Deve_Aceitar_Name_Vazio()
        {
            var dto = new VersaoGitHubRetornoDto { Name = string.Empty };

            Assert.Equal(string.Empty, dto.Name);
        }

        [Fact]
        public void Deve_Aceitar_Name_Com_Versao_Semantica()
        {
            var dto = new VersaoGitHubRetornoDto { Name = "v2.3.1" };

            Assert.Equal("v2.3.1", dto.Name);
        }

        [Fact]
        public void Deve_Aceitar_Name_Com_Sufixo_Pre_Release()
        {
            var dto = new VersaoGitHubRetornoDto { Name = "v3.0.0-beta.1" };

            Assert.Equal("v3.0.0-beta.1", dto.Name);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Name_Apos_Atribuicao()
        {
            var dto = new VersaoGitHubRetornoDto { Name = "v1.0.0" };
            dto.Name = "v1.0.1";

            Assert.Equal("v1.0.1", dto.Name);
        }

        [Fact]
        public void Deve_Aceitar_Name_Com_Espacos()
        {
            var dto = new VersaoGitHubRetornoDto { Name = "versao 1.0.0" };

            Assert.Equal("versao 1.0.0", dto.Name);
        }

        [Fact]
        public void Deve_Aceitar_Name_Longo()
        {
            var nome = new string('a', 500);
            var dto = new VersaoGitHubRetornoDto { Name = nome };

            Assert.Equal(nome, dto.Name);
        }
    }
}