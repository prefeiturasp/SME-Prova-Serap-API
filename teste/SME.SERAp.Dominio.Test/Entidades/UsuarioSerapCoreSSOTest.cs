using System;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class UsuarioSerapCoreSSOTest
    {
        [Fact]
        public void Deve_Criar_UsuarioSerapCoreSSO_Com_Construtor_Padrao()
        {
            var guid = Guid.NewGuid();
            var criadoEm = new DateTime(2024, 1, 1);
            var atualizadoEm = new DateTime(2024, 6, 1);

            var usuario = new UsuarioSerapCoreSSO
            {
                IdCoreSSO = guid,
                Login = "usuario.teste",
                Nome = "Usuário Teste",
                CriadoEm = criadoEm,
                AtualizadoEm = atualizadoEm
            };

            Assert.Equal(guid, usuario.IdCoreSSO);
            Assert.Equal("usuario.teste", usuario.Login);
            Assert.Equal("Usuário Teste", usuario.Nome);
            Assert.Equal(criadoEm, usuario.CriadoEm);
            Assert.Equal(atualizadoEm, usuario.AtualizadoEm);
        }

        [Fact]
        public void Deve_Criar_UsuarioSerapCoreSSO_Com_Valores_Default()
        {
            var usuario = new UsuarioSerapCoreSSO();

            Assert.Equal(Guid.Empty, usuario.IdCoreSSO);
            Assert.Null(usuario.Login);
            Assert.Null(usuario.Nome);
            Assert.Equal(default(DateTime), usuario.CriadoEm);
            Assert.Equal(default(DateTime), usuario.AtualizadoEm);
        }

        [Fact]
        public void Deve_Criar_UsuarioSerapCoreSSO_Com_IdCoreSSO_Especifico()
        {
            var guid = Guid.Parse("aaaabbbb-cccc-dddd-eeee-ffffffffffff");
            var usuario = new UsuarioSerapCoreSSO { IdCoreSSO = guid };

            Assert.Equal(guid, usuario.IdCoreSSO);
        }

        [Fact]
        public void Deve_Criar_UsuarioSerapCoreSSO_Com_Login_Nulo()
        {
            var usuario = new UsuarioSerapCoreSSO { Login = null };

            Assert.Null(usuario.Login);
        }

        [Fact]
        public void Deve_Criar_UsuarioSerapCoreSSO_Com_Nome_Nulo()
        {
            var usuario = new UsuarioSerapCoreSSO { Nome = null };

            Assert.Null(usuario.Nome);
        }

        [Fact]
        public void Deve_Criar_Dois_UsuarioSerapCoreSSO_Com_IdCoreSSO_Distintos()
        {
            var usuario1 = new UsuarioSerapCoreSSO { IdCoreSSO = Guid.NewGuid() };
            var usuario2 = new UsuarioSerapCoreSSO { IdCoreSSO = Guid.NewGuid() };

            Assert.NotEqual(usuario1.IdCoreSSO, usuario2.IdCoreSSO);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var usuario = new UsuarioSerapCoreSSO { Login = "login.original", Nome = "Nome Original" };
            usuario.Login = "login.novo";
            usuario.Nome = "Nome Novo";

            Assert.Equal("login.novo", usuario.Login);
            Assert.Equal("Nome Novo", usuario.Nome);
        }

        [Fact]
        public void Deve_Criar_UsuarioSerapCoreSSO_Herdando_EntidadeBase()
        {
            var usuario = new UsuarioSerapCoreSSO();
            usuario.Id = 99;

            Assert.Equal(99, usuario.Id);
        }
    }
}