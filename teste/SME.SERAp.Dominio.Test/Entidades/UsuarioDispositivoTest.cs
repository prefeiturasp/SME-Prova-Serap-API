using System;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class UsuarioDispositivoTest
    {
        [Fact]
        public void Deve_Criar_UsuarioDispositivo_Com_Construtor_Parametros()
        {
            var antes = DateTime.Now;
            var dispositivo = new UsuarioDispositivo("device-001", 123456, 2024);
            var depois = DateTime.Now;

            Assert.Equal("device-001", dispositivo.DispositivoId);
            Assert.Equal(123456, dispositivo.Ra);
            Assert.Equal(2024, dispositivo.Ano);
            Assert.InRange(dispositivo.CriadoEm, antes, depois);
        }

        [Fact]
        public void Deve_Criar_UsuarioDispositivo_Com_Construtor_Padrao()
        {
            var antes = DateTime.Now;
            var dispositivo = new UsuarioDispositivo
            {
                DispositivoId = "device-002",
                Ra = 654321,
                Ano = 2023
            };
            var depois = DateTime.Now;

            Assert.Equal("device-002", dispositivo.DispositivoId);
            Assert.Equal(654321, dispositivo.Ra);
            Assert.Equal(2023, dispositivo.Ano);
            Assert.InRange(dispositivo.CriadoEm, antes, depois);
        }

        [Fact]
        public void Deve_Definir_CriadoEm_Automaticamente_No_Construtor_Padrao()
        {
            var antes = DateTime.Now;
            var dispositivo = new UsuarioDispositivo();
            var depois = DateTime.Now;

            Assert.InRange(dispositivo.CriadoEm, antes, depois);
        }

        [Fact]
        public void Deve_Definir_CriadoEm_Automaticamente_No_Construtor_Parametros()
        {
            var antes = DateTime.Now;
            var dispositivo = new UsuarioDispositivo("dev", 1, 2024);
            var depois = DateTime.Now;

            Assert.InRange(dispositivo.CriadoEm, antes, depois);
        }

        [Fact]
        public void Deve_Criar_UsuarioDispositivo_Com_Valores_Default()
        {
            var dispositivo = new UsuarioDispositivo();

            Assert.Null(dispositivo.DispositivoId);
            Assert.Equal(0, dispositivo.Ra);
            Assert.Equal(0, dispositivo.Ano);
        }

        [Fact]
        public void Deve_Criar_UsuarioDispositivo_Com_DispositivoId_Nulo()
        {
            var dispositivo = new UsuarioDispositivo(null, 1, 2024);

            Assert.Null(dispositivo.DispositivoId);
        }

        [Fact]
        public void Deve_Criar_UsuarioDispositivo_Com_Ra_Maximo()
        {
            var dispositivo = new UsuarioDispositivo("dev", long.MaxValue, 2024);

            Assert.Equal(long.MaxValue, dispositivo.Ra);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var dispositivo = new UsuarioDispositivo("dev-original", 100, 2023);
            dispositivo.DispositivoId = "dev-novo";
            dispositivo.Ra = 200;
            dispositivo.Ano = 2024;

            Assert.Equal("dev-novo", dispositivo.DispositivoId);
            Assert.Equal(200, dispositivo.Ra);
            Assert.Equal(2024, dispositivo.Ano);
        }

        [Fact]
        public void Deve_Criar_UsuarioDispositivo_Herdando_EntidadeBase()
        {
            var dispositivo = new UsuarioDispositivo("dev", 1, 2024);
            dispositivo.Id = 88;

            Assert.Equal(88, dispositivo.Id);
        }
    }
}