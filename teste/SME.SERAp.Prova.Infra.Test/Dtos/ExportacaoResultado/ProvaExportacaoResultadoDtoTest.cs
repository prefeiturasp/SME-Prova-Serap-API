using System;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.ExportacaoResultado
{
    public class ProvaExportacaoResultadoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaExportacaoResultadoDto_Com_Propriedades_Padrao()
        {
            var dto = new ProvaExportacaoResultadoDto();

            Assert.Equal(0, dto.ProvaId);
            Assert.Equal(0, dto.ProvaLegadoId);
            Assert.Equal(0, dto.ProcessoId);
            Assert.Null(dto.Descricao);
            Assert.Null(dto.NomeProva);
            Assert.Equal(default(DateTime), dto.DataInicio);
            Assert.Equal(default(DateTime), dto.DataFim);
            Assert.Equal(default(ExportacaoResultadoStatus), dto.Status);
            Assert.Equal(default(DateTime), dto.CriadoEm);
            Assert.Null(dto.UltimaExportacao);
        }

        [Fact]
        public void Deve_Atribuir_ProvaId_Corretamente()
        {
            var dto = new ProvaExportacaoResultadoDto { ProvaId = 42 };
            Assert.Equal(42, dto.ProvaId);
        }

        [Fact]
        public void Deve_Atribuir_ProvaLegadoId_Corretamente()
        {
            var dto = new ProvaExportacaoResultadoDto { ProvaLegadoId = 99 };
            Assert.Equal(99, dto.ProvaLegadoId);
        }

        [Fact]
        public void Deve_Atribuir_ProcessoId_Corretamente()
        {
            var dto = new ProvaExportacaoResultadoDto { ProcessoId = 7 };
            Assert.Equal(7, dto.ProcessoId);
        }

        [Fact]
        public void Deve_Atribuir_Descricao_Corretamente()
        {
            var dto = new ProvaExportacaoResultadoDto { Descricao = "Prova Anual" };
            Assert.Equal("Prova Anual", dto.Descricao);
        }

        [Fact]
        public void Deve_Atribuir_NomeProva_Corretamente()
        {
            var dto = new ProvaExportacaoResultadoDto { NomeProva = "Avaliação Final" };
            Assert.Equal("Avaliação Final", dto.NomeProva);
        }

        [Fact]
        public void Deve_Atribuir_DataInicio_Corretamente()
        {
            var data = new DateTime(2024, 2, 1);
            var dto = new ProvaExportacaoResultadoDto { DataInicio = data };
            Assert.Equal(data, dto.DataInicio);
        }

        [Fact]
        public void Deve_Atribuir_DataFim_Corretamente()
        {
            var data = new DateTime(2024, 2, 28);
            var dto = new ProvaExportacaoResultadoDto { DataFim = data };
            Assert.Equal(data, dto.DataFim);
        }

        [Fact]
        public void Deve_Atribuir_Status_Processando()
        {
            var dto = new ProvaExportacaoResultadoDto { Status = ExportacaoResultadoStatus.Processando };
            Assert.Equal(ExportacaoResultadoStatus.Processando, dto.Status);
        }

        [Fact]
        public void Deve_Atribuir_Status_Concluido()
        {
            var dto = new ProvaExportacaoResultadoDto { Status = ExportacaoResultadoStatus.Finalizado };
            Assert.Equal(ExportacaoResultadoStatus.Finalizado, dto.Status);
        }

        [Fact]
        public void Deve_Atribuir_Status_Erro()
        {
            var dto = new ProvaExportacaoResultadoDto { Status = ExportacaoResultadoStatus.Erro };
            Assert.Equal(ExportacaoResultadoStatus.Erro, dto.Status);
        }

        [Fact]
        public void Deve_Atribuir_CriadoEm_Corretamente()
        {
            var data = new DateTime(2024, 1, 5);
            var dto = new ProvaExportacaoResultadoDto { CriadoEm = data };
            Assert.Equal(data, dto.CriadoEm);
        }

        [Fact]
        public void Deve_Atribuir_UltimaExportacao_Corretamente()
        {
            var data = new DateTime(2024, 3, 20, 14, 0, 0);
            var dto = new ProvaExportacaoResultadoDto { UltimaExportacao = data };
            Assert.Equal(data, dto.UltimaExportacao);
        }

        [Fact]
        public void Deve_Aceitar_UltimaExportacao_Nula()
        {
            var dto = new ProvaExportacaoResultadoDto { UltimaExportacao = null };
            Assert.Null(dto.UltimaExportacao);
        }

        [Fact]
        public void Deve_Criar_ProvaExportacaoResultadoDto_Completo()
        {
            var dto = new ProvaExportacaoResultadoDto
            {
                ProvaId = 1,
                ProvaLegadoId = 2,
                ProcessoId = 3,
                Descricao = "Prova de Ciências",
                NomeProva = "Ciências 2024",
                DataInicio = new DateTime(2024, 4, 1),
                DataFim = new DateTime(2024, 4, 30),
                Status = ExportacaoResultadoStatus.Finalizado,
                CriadoEm = new DateTime(2024, 3, 15),
                UltimaExportacao = new DateTime(2024, 5, 1)
            };

            Assert.Equal(1, dto.ProvaId);
            Assert.Equal(2, dto.ProvaLegadoId);
            Assert.Equal(3, dto.ProcessoId);
            Assert.Equal("Prova de Ciências", dto.Descricao);
            Assert.Equal("Ciências 2024", dto.NomeProva);
            Assert.Equal(new DateTime(2024, 4, 1), dto.DataInicio);
            Assert.Equal(new DateTime(2024, 4, 30), dto.DataFim);
            Assert.Equal(ExportacaoResultadoStatus.Finalizado, dto.Status);
            Assert.Equal(new DateTime(2024, 3, 15), dto.CriadoEm);
            Assert.Equal(new DateTime(2024, 5, 1), dto.UltimaExportacao);
        }

        [Fact]
        public void Deve_Aceitar_ProvaId_Valor_Maximo_Long()
        {
            var dto = new ProvaExportacaoResultadoDto { ProvaId = long.MaxValue };
            Assert.Equal(long.MaxValue, dto.ProvaId);
        }

        [Fact]
        public void Deve_Aceitar_Descricao_Nula()
        {
            var dto = new ProvaExportacaoResultadoDto { Descricao = null };
            Assert.Null(dto.Descricao);
        }

        [Fact]
        public void DataInicio_Deve_Ser_Anterior_Ou_Igual_A_DataFim()
        {
            var dto = new ProvaExportacaoResultadoDto
            {
                DataInicio = new DateTime(2024, 1, 1),
                DataFim = new DateTime(2024, 12, 31)
            };

            Assert.True(dto.DataInicio <= dto.DataFim);
        }
    }
}