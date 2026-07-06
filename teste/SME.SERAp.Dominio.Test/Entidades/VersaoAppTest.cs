using System;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class VersaoAppTest
    {
        [Fact]
        public void Deve_Criar_VersaoApp_Com_Construtor_Padrao()
        {
            var criadoEm = new DateTime(2024, 1, 1);
            var alteradoEm = new DateTime(2024, 6, 1);

            var versao = new VersaoApp
            {
                Codigo = 10,
                Descricao = "v1.0.0",
                Mensagem = "Nova versão disponível",
                CriadoEm = criadoEm,
                AlteradoEm = alteradoEm,
                SuporteMinimo = 5,
                Url = "https://app.example.com/download"
            };

            Assert.Equal(10, versao.Codigo);
            Assert.Equal("v1.0.0", versao.Descricao);
            Assert.Equal("Nova versão disponível", versao.Mensagem);
            Assert.Equal(criadoEm, versao.CriadoEm);
            Assert.Equal(alteradoEm, versao.AlteradoEm);
            Assert.Equal(5, versao.SuporteMinimo);
            Assert.Equal("https://app.example.com/download", versao.Url);
        }

        [Fact]
        public void Deve_Criar_VersaoApp_Com_Valores_Default()
        {
            var versao = new VersaoApp();

            Assert.Equal(0, versao.Codigo);
            Assert.Null(versao.Descricao);
            Assert.Null(versao.Mensagem);
            Assert.Equal(default(DateTime), versao.CriadoEm);
            Assert.Equal(default(DateTime), versao.AlteradoEm);
            Assert.Equal(0, versao.SuporteMinimo);
            Assert.Null(versao.Url);
        }

        [Fact]
        public void Deve_Criar_VersaoApp_Com_Descricao_Nula()
        {
            var versao = new VersaoApp { Descricao = null };

            Assert.Null(versao.Descricao);
        }

        [Fact]
        public void Deve_Criar_VersaoApp_Com_Mensagem_Nula()
        {
            var versao = new VersaoApp { Mensagem = null };

            Assert.Null(versao.Mensagem);
        }

        [Fact]
        public void Deve_Criar_VersaoApp_Com_Url_Nula()
        {
            var versao = new VersaoApp { Url = null };

            Assert.Null(versao.Url);
        }

        [Fact]
        public void Deve_Criar_VersaoApp_Com_SuporteMinimo_Igual_Codigo()
        {
            var versao = new VersaoApp { Codigo = 8, SuporteMinimo = 8 };

            Assert.Equal(versao.Codigo, versao.SuporteMinimo);
        }

        [Fact]
        public void Deve_Criar_VersaoApp_Com_SuporteMinimo_Menor_Que_Codigo()
        {
            var versao = new VersaoApp { Codigo = 10, SuporteMinimo = 7 };

            Assert.True(versao.SuporteMinimo < versao.Codigo);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var versao = new VersaoApp { Codigo = 1, Descricao = "v0.1" };
            versao.Codigo = 2;
            versao.Descricao = "v0.2";
            versao.Url = "https://nova.url";

            Assert.Equal(2, versao.Codigo);
            Assert.Equal("v0.2", versao.Descricao);
            Assert.Equal("https://nova.url", versao.Url);
        }

        [Fact]
        public void Deve_Criar_VersaoApp_Herdando_EntidadeBase()
        {
            var versao = new VersaoApp();
            versao.Id = 15;

            Assert.Equal(15, versao.Id);
        }
    }
}