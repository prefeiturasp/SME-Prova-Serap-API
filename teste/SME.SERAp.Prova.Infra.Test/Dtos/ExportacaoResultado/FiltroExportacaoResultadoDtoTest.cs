using System;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.ExportacaoResultado
{
    public class FiltroExportacaoResultadoDtoTest
    {
        [Fact]
        public void Deve_Criar_FiltroExportacaoResultadoDto_Com_Propriedades_Padrao()
        {
            var dto = new FiltroExportacaoResultadoDto();

            Assert.Null(dto.DataInicio);
            Assert.Null(dto.DataFim);
            Assert.Equal(0, dto.ProvaSerapId);
            Assert.Null(dto.DescricaoProva);
            Assert.Equal(0, dto.QuantidadeRegistros);
            Assert.Equal(0, dto.NumeroPagina);
        }

        [Fact]
        public void Deve_Atribuir_DataInicio_Corretamente()
        {
            var data = new DateTime(2024, 1, 1);
            var dto = new FiltroExportacaoResultadoDto { DataInicio = data };
            Assert.Equal(data, dto.DataInicio);
        }

        [Fact]
        public void Deve_Aceitar_DataInicio_Nula()
        {
            var dto = new FiltroExportacaoResultadoDto { DataInicio = null };
            Assert.Null(dto.DataInicio);
        }

        [Fact]
        public void Deve_Atribuir_DataFim_Corretamente()
        {
            var data = new DateTime(2024, 12, 31);
            var dto = new FiltroExportacaoResultadoDto { DataFim = data };
            Assert.Equal(data, dto.DataFim);
        }

        [Fact]
        public void Deve_Aceitar_DataFim_Nula()
        {
            var dto = new FiltroExportacaoResultadoDto { DataFim = null };
            Assert.Null(dto.DataFim);
        }

        [Fact]
        public void Deve_Atribuir_ProvaSerapId_Corretamente()
        {
            var dto = new FiltroExportacaoResultadoDto { ProvaSerapId = 300 };
            Assert.Equal(300, dto.ProvaSerapId);
        }

        [Fact]
        public void Deve_Atribuir_DescricaoProva_Corretamente()
        {
            var dto = new FiltroExportacaoResultadoDto { DescricaoProva = "Prova de Matemática" };
            Assert.Equal("Prova de Matemática", dto.DescricaoProva);
        }

        [Fact]
        public void Deve_Aceitar_DescricaoProva_Nula()
        {
            var dto = new FiltroExportacaoResultadoDto { DescricaoProva = null };
            Assert.Null(dto.DescricaoProva);
        }

        [Fact]
        public void Deve_Atribuir_QuantidadeRegistros_Corretamente()
        {
            var dto = new FiltroExportacaoResultadoDto { QuantidadeRegistros = 50 };
            Assert.Equal(50, dto.QuantidadeRegistros);
        }

        [Fact]
        public void Deve_Atribuir_NumeroPagina_Corretamente()
        {
            var dto = new FiltroExportacaoResultadoDto { NumeroPagina = 3 };
            Assert.Equal(3, dto.NumeroPagina);
        }

        [Fact]
        public void Deve_Criar_FiltroExportacaoResultadoDto_Completo()
        {
            var dto = new FiltroExportacaoResultadoDto
            {
                DataInicio = new DateTime(2024, 1, 1),
                DataFim = new DateTime(2024, 6, 30),
                ProvaSerapId = 10,
                DescricaoProva = "Avaliação 2024",
                QuantidadeRegistros = 25,
                NumeroPagina = 1
            };

            Assert.Equal(new DateTime(2024, 1, 1), dto.DataInicio);
            Assert.Equal(new DateTime(2024, 6, 30), dto.DataFim);
            Assert.Equal(10, dto.ProvaSerapId);
            Assert.Equal("Avaliação 2024", dto.DescricaoProva);
            Assert.Equal(25, dto.QuantidadeRegistros);
            Assert.Equal(1, dto.NumeroPagina);
        }

        [Fact]
        public void Deve_Aceitar_NumeroPagina_Zero()
        {
            var dto = new FiltroExportacaoResultadoDto { NumeroPagina = 0 };
            Assert.Equal(0, dto.NumeroPagina);
        }

        [Fact]
        public void Deve_Aceitar_QuantidadeRegistros_Zero()
        {
            var dto = new FiltroExportacaoResultadoDto { QuantidadeRegistros = 0 };
            Assert.Equal(0, dto.QuantidadeRegistros);
        }

        [Fact]
        public void Deve_Aceitar_ProvaSerapId_Valor_Maximo_Long()
        {
            var dto = new FiltroExportacaoResultadoDto { ProvaSerapId = long.MaxValue };
            Assert.Equal(long.MaxValue, dto.ProvaSerapId);
        }
    }
}