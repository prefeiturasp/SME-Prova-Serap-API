using System;
using System.Threading;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class UsuarioTest
    {
        [Fact]
        public void Deve_Criar_Usuario_Com_Construtor_Parametros()
        {
            var antes = DateTime.Now;
            var usuario = new Usuario("João Silva", 123456);
            var depois = DateTime.Now;

            Assert.Equal("João Silva", usuario.Nome);
            Assert.Equal(123456, usuario.Login);
            Assert.InRange(usuario.CriadoEm, antes, depois);
            Assert.InRange(usuario.UltimoLogin, antes, depois);
        }

        [Fact]
        public void Deve_Criar_Usuario_Com_Construtor_Padrao()
        {
            var criadoEm = new DateTime(2024, 1, 1);
            var ultimoLogin = new DateTime(2024, 6, 10);

            var usuario = new Usuario
            {
                Nome = "Maria",
                Login = 654321,
                CriadoEm = criadoEm,
                UltimoLogin = ultimoLogin
            };

            Assert.Equal("Maria", usuario.Nome);
            Assert.Equal(654321, usuario.Login);
            Assert.Equal(criadoEm, usuario.CriadoEm);
            Assert.Equal(ultimoLogin, usuario.UltimoLogin);
        }

        [Fact]
        public void Deve_Criar_Usuario_Com_Valores_Default()
        {
            var usuario = new Usuario();

            Assert.Null(usuario.Nome);
            Assert.Equal(0, usuario.Login);
            Assert.Equal(default(DateTime), usuario.CriadoEm);
            Assert.Equal(default(DateTime), usuario.UltimoLogin);
        }

        [Fact]
        public void Deve_Definir_CriadoEm_Automaticamente_No_Construtor_Parametros()
        {
            var antes = DateTime.Now;
            var usuario = new Usuario("Ana", 111);
            var depois = DateTime.Now;

            Assert.InRange(usuario.CriadoEm, antes, depois);
        }

        [Fact]
        public void Deve_Definir_UltimoLogin_Automaticamente_No_Construtor_Parametros()
        {
            var antes = DateTime.Now;
            var usuario = new Usuario("Pedro", 222);
            var depois = DateTime.Now;

            Assert.InRange(usuario.UltimoLogin, antes, depois);
        }

        [Fact]
        public void AtualizaUltimoLogin_Deve_Atualizar_UltimoLogin()
        {
            var usuario = new Usuario("Carlos", 333);
            var loginAnterior = usuario.UltimoLogin;

            Thread.Sleep(10);
            usuario.AtualizaUltimoLogin();

            Assert.True(usuario.UltimoLogin >= loginAnterior);
        }

        [Fact]
        public void AtualizaUltimoLogin_Deve_Ser_Proximo_De_Agora()
        {
            var usuario = new Usuario("Lucas", 444);

            var antes = DateTime.Now;
            usuario.AtualizaUltimoLogin();
            var depois = DateTime.Now;

            Assert.InRange(usuario.UltimoLogin, antes, depois);
        }

        [Fact]
        public void AtualizaUltimoLogin_Nao_Deve_Alterar_CriadoEm()
        {
            var usuario = new Usuario("Paula", 555);
            var criadoEmOriginal = usuario.CriadoEm;

            Thread.Sleep(10);
            usuario.AtualizaUltimoLogin();

            Assert.Equal(criadoEmOriginal, usuario.CriadoEm);
        }

        [Fact]
        public void Deve_Criar_Usuario_Com_Nome_Nulo()
        {
            var usuario = new Usuario(null, 999);

            Assert.Null(usuario.Nome);
        }

        [Fact]
        public void Deve_Criar_Usuario_Com_Login_Maximo()
        {
            var usuario = new Usuario("Teste", long.MaxValue);

            Assert.Equal(long.MaxValue, usuario.Login);
        }

        [Fact]
        public void Deve_Alterar_Nome_Apos_Criacao()
        {
            var usuario = new Usuario("Original", 100);
            usuario.Nome = "Alterado";

            Assert.Equal("Alterado", usuario.Nome);
        }

        [Fact]
        public void Deve_Criar_Usuario_Herdando_EntidadeBase()
        {
            var usuario = new Usuario("Teste", 1);
            usuario.Id = 77;

            Assert.Equal(77, usuario.Id);
        }
    }
}