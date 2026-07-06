using System;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class TipoDeficienciaTest
    {
        [Fact]
        public void Deve_Criar_TipoDeficiencia_Com_Construtor_Padrao()
        {
            var guid = Guid.NewGuid();
            var criadoEm = new DateTime(2024, 1, 10);
            var atualizadoEm = new DateTime(2024, 6, 15);

            var deficiencia = new TipoDeficiencia
            {
                LegadoId = guid,
                CodigoEol = 42,
                Nome = "Deficiência Visual",
                CriadoEm = criadoEm,
                AtualizadoEm = atualizadoEm,
                ProvaNormal = true
            };

            Assert.Equal(guid, deficiencia.LegadoId);
            Assert.Equal(42, deficiencia.CodigoEol);
            Assert.Equal("Deficiência Visual", deficiencia.Nome);
            Assert.Equal(criadoEm, deficiencia.CriadoEm);
            Assert.Equal(atualizadoEm, deficiencia.AtualizadoEm);
            Assert.True(deficiencia.ProvaNormal);
        }

        [Fact]
        public void Deve_Criar_TipoDeficiencia_Com_Valores_Default()
        {
            var deficiencia = new TipoDeficiencia();

            Assert.Equal(Guid.Empty, deficiencia.LegadoId);
            Assert.Equal(0, deficiencia.CodigoEol);
            Assert.Null(deficiencia.Nome);
            Assert.Equal(default(DateTime), deficiencia.CriadoEm);
            Assert.Equal(default(DateTime), deficiencia.AtualizadoEm);
            Assert.False(deficiencia.ProvaNormal);
        }

        [Fact]
        public void Deve_Criar_TipoDeficiencia_Com_ProvaNormal_True()
        {
            var deficiencia = new TipoDeficiencia { ProvaNormal = true };

            Assert.True(deficiencia.ProvaNormal);
        }

        [Fact]
        public void Deve_Criar_TipoDeficiencia_Com_ProvaNormal_False()
        {
            var deficiencia = new TipoDeficiencia { ProvaNormal = false };

            Assert.False(deficiencia.ProvaNormal);
        }

        [Fact]
        public void Deve_Criar_TipoDeficiencia_Com_LegadoId_Especifico()
        {
            var guid = Guid.Parse("12345678-1234-1234-1234-123456789012");
            var deficiencia = new TipoDeficiencia { LegadoId = guid };

            Assert.Equal(guid, deficiencia.LegadoId);
        }

        [Fact]
        public void Deve_Criar_TipoDeficiencia_Com_Nome_Nulo()
        {
            var deficiencia = new TipoDeficiencia { Nome = null };

            Assert.Null(deficiencia.Nome);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var deficiencia = new TipoDeficiencia { Nome = "Original", CodigoEol = 1 };
            deficiencia.Nome = "Alterado";
            deficiencia.CodigoEol = 99;
            deficiencia.ProvaNormal = true;

            Assert.Equal("Alterado", deficiencia.Nome);
            Assert.Equal(99, deficiencia.CodigoEol);
            Assert.True(deficiencia.ProvaNormal);
        }

        [Fact]
        public void Deve_Criar_TipoDeficiencia_Com_LegadoIds_Distintos()
        {
            var def1 = new TipoDeficiencia { LegadoId = Guid.NewGuid() };
            var def2 = new TipoDeficiencia { LegadoId = Guid.NewGuid() };

            Assert.NotEqual(def1.LegadoId, def2.LegadoId);
        }

        [Fact]
        public void Deve_Criar_TipoDeficiencia_Herdando_EntidadeBase()
        {
            var deficiencia = new TipoDeficiencia();
            deficiencia.Id = 20;

            Assert.Equal(20, deficiencia.Id);
        }
    }
}