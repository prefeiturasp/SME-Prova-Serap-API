using System;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.ExportacaoResultado
{
    public class ExportacaoResultadoDtoTest
    {
        [Fact]
        public void Deve_Criar_ExportacaoResultadoDto_Com_Construtor_Parametros()
        {
            var criadoEm = new DateTime(2024, 1, 1);
            var atualizadoEm = new DateTime(2024, 1, 10);

            var dto = new ExportacaoResultadoDto(100, "resultado.csv", criadoEm, atualizadoEm, ExportacaoResultadoStatus.Processando);

            Assert.Equal(100, dto.ProvaSerapId);
            Assert.Equal("resultado.csv", dto.NomeArquivo);
            Assert.Equal(criadoEm, dto.CriadoEm);
            Assert.Equal(atualizadoEm, dto.AtualizadoEm);
            Assert.Equal(ExportacaoResultadoStatus.Processando, dto.Status);
        }

        [Fact]
        public void Deve_Atribuir_ProvaSerapId_Corretamente()
        {
            var dto = new ExportacaoResultadoDto(999, "f.csv", DateTime.Today, DateTime.Today, ExportacaoResultadoStatus.Cancelado);
            Assert.Equal(999, dto.ProvaSerapId);
        }

        [Fact]
        public void Deve_Atribuir_NomeArquivo_Corretamente()
        {
            var dto = new ExportacaoResultadoDto(1, "exportacao_2024.csv", DateTime.Today, DateTime.Today, ExportacaoResultadoStatus.Finalizado);
            Assert.Equal("exportacao_2024.csv", dto.NomeArquivo);
        }

        [Fact]
        public void Deve_Atribuir_Status_Processando()
        {
            var dto = new ExportacaoResultadoDto(1, "f.csv", DateTime.Today, DateTime.Today, ExportacaoResultadoStatus.Processando);
            Assert.Equal(ExportacaoResultadoStatus.Processando, dto.Status);
        }

        [Fact]
        public void Deve_Atribuir_Status_Concluido()
        {
            var dto = new ExportacaoResultadoDto(1, "f.csv", DateTime.Today, DateTime.Today, ExportacaoResultadoStatus.Finalizado);
            Assert.Equal(ExportacaoResultadoStatus.Finalizado, dto.Status);
        }

        [Fact]
        public void Deve_Atribuir_Status_Erro()
        {
            var dto = new ExportacaoResultadoDto(1, "f.csv", DateTime.Today, DateTime.Today, ExportacaoResultadoStatus.Erro);
            Assert.Equal(ExportacaoResultadoStatus.Erro, dto.Status);
        }

        [Fact]
        public void Deve_Atribuir_CriadoEm_Corretamente()
        {
            var data = new DateTime(2024, 3, 15, 9, 0, 0);
            var dto = new ExportacaoResultadoDto(1, "f.csv", data, DateTime.Today, ExportacaoResultadoStatus.Finalizado);
            Assert.Equal(data, dto.CriadoEm);
        }

        [Fact]
        public void Deve_Atribuir_AtualizadoEm_Corretamente()
        {
            var data = new DateTime(2024, 4, 20, 15, 30, 0);
            var dto = new ExportacaoResultadoDto(1, "f.csv", DateTime.Today, data, ExportacaoResultadoStatus.Finalizado);
            Assert.Equal(data, dto.AtualizadoEm);
        }

        [Fact]
        public void Deve_Aceitar_NomeArquivo_Nulo()
        {
            var dto = new ExportacaoResultadoDto(1, null, DateTime.Today, DateTime.Today, ExportacaoResultadoStatus.Processando);
            Assert.Null(dto.NomeArquivo);
        }

        [Fact]
        public void Deve_Aceitar_ProvaSerapId_Valor_Maximo_Long()
        {
            var dto = new ExportacaoResultadoDto(long.MaxValue, "f.csv", DateTime.Today, DateTime.Today, ExportacaoResultadoStatus.Finalizado);
            Assert.Equal(long.MaxValue, dto.ProvaSerapId);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Construcao()
        {
            var dto = new ExportacaoResultadoDto(1, "antigo.csv", DateTime.Today, DateTime.Today, ExportacaoResultadoStatus.Processando);
            dto.NomeArquivo = "novo.csv";
            dto.Status = ExportacaoResultadoStatus.Finalizado;

            Assert.Equal("novo.csv", dto.NomeArquivo);
            Assert.Equal(ExportacaoResultadoStatus.Finalizado, dto.Status);
        }

        [Fact]
        public void CriadoEm_Deve_Ser_Anterior_Ou_Igual_A_AtualizadoEm()
        {
            var criadoEm = new DateTime(2024, 1, 1);
            var atualizadoEm = new DateTime(2024, 6, 1);
            var dto = new ExportacaoResultadoDto(1, "f.csv", criadoEm, atualizadoEm, ExportacaoResultadoStatus.Finalizado);

            Assert.True(dto.CriadoEm <= dto.AtualizadoEm);
        }
    }
}