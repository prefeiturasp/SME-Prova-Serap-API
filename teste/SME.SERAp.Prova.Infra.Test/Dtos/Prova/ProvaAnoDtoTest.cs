using System;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaAnoDtoTest
    {
        private ProvaAnoDto CriarDtoCompleto()
        {
            return new ProvaAnoDto
            {
                Id = 1,
                Descricao = "Prova Anual",
                InicioDownload = new DateTime(2024, 1, 10),
                Inicio = new DateTime(2024, 2, 1),
                Fim = new DateTime(2024, 2, 28),
                TempoExecucao = 90,
                Inclusao = new DateTime(2024, 1, 5),
                TotalItens = 30,
                TotalCadernos = 4,
                LegadoId = 55,
                Senha = "pass123",
                PossuiBIB = true,
                Modalidade = Modalidade.Fundamental,
                Ano = "7",
                EtapaEja = 0,
                QuantidadeRespostaSincronizacao = 5,
                UltimaAtualizacao = new DateTime(2024, 1, 20),
                Deficiente = false,
                ProvaComProficiencia = true,
                ApresentarResultados = true,
                ApresentarResultadosPorItem = false,
                FormatoTai = true,
                FormatoTaiItem = 10,
                FormatoTaiAvancarSemResponder = false,
                FormatoTaiVoltarItemAnterior = true,
                ExibirAudio = false,
                ExibirVideo = true
            };
        }

        [Fact]
        public void Deve_Criar_ProvaAnoDto_Com_Propriedades_Padrao()
        {
            var dto = new ProvaAnoDto();

            Assert.Equal(0, dto.Id);
            Assert.Null(dto.Descricao);
            Assert.Null(dto.InicioDownload);
            Assert.Equal(default(DateTime), dto.Inicio);
            Assert.Equal(default(DateTime), dto.Fim);
            Assert.Equal(0, dto.TempoExecucao);
            Assert.Equal(default(DateTime), dto.Inclusao);
            Assert.Equal(0, dto.TotalItens);
            Assert.Equal(0, dto.TotalCadernos);
            Assert.Equal(0, dto.LegadoId);
            Assert.Null(dto.Senha);
            Assert.False(dto.PossuiBIB);
            Assert.Equal(default(Modalidade), dto.Modalidade);
            Assert.Null(dto.Ano);
            Assert.Equal(0, dto.EtapaEja);
            Assert.Null(dto.QuantidadeRespostaSincronizacao);
            Assert.Equal(default(DateTime), dto.UltimaAtualizacao);
            Assert.False(dto.Deficiente);
            Assert.False(dto.ProvaComProficiencia);
            Assert.False(dto.ApresentarResultados);
            Assert.False(dto.ApresentarResultadosPorItem);
            Assert.False(dto.FormatoTai);
            Assert.Null(dto.FormatoTaiItem);
            Assert.False(dto.FormatoTaiAvancarSemResponder);
            Assert.False(dto.FormatoTaiVoltarItemAnterior);
            Assert.False(dto.ExibirAudio);
            Assert.False(dto.ExibirVideo);
        }

        [Fact]
        public void Deve_Criar_ProvaAnoDto_Completo()
        {
            var dto = CriarDtoCompleto();

            Assert.Equal(1, dto.Id);
            Assert.Equal("Prova Anual", dto.Descricao);
            Assert.Equal(new DateTime(2024, 1, 10), dto.InicioDownload);
            Assert.Equal(new DateTime(2024, 2, 1), dto.Inicio);
            Assert.Equal(new DateTime(2024, 2, 28), dto.Fim);
            Assert.Equal(90, dto.TempoExecucao);
            Assert.Equal(30, dto.TotalItens);
            Assert.Equal(4, dto.TotalCadernos);
            Assert.Equal(55, dto.LegadoId);
            Assert.Equal("pass123", dto.Senha);
            Assert.True(dto.PossuiBIB);
            Assert.Equal(Modalidade.Fundamental, dto.Modalidade);
            Assert.Equal("7", dto.Ano);
            Assert.Equal(5, dto.QuantidadeRespostaSincronizacao);
            Assert.True(dto.ProvaComProficiencia);
            Assert.True(dto.ApresentarResultados);
            Assert.False(dto.ApresentarResultadosPorItem);
            Assert.True(dto.FormatoTai);
            Assert.Equal(10, dto.FormatoTaiItem);
            Assert.False(dto.FormatoTaiAvancarSemResponder);
            Assert.True(dto.FormatoTaiVoltarItemAnterior);
            Assert.False(dto.ExibirAudio);
            Assert.True(dto.ExibirVideo);
        }

        [Fact]
        public void ObterDataInicioMais3Horas_Deve_Retornar_Inicio_Mais_3_Horas()
        {
            var inicio = new DateTime(2024, 3, 1, 8, 0, 0);
            var dto = new ProvaAnoDto { Inicio = inicio };

            var resultado = dto.ObterDataInicioMais3Horas();

            Assert.Equal(inicio.AddHours(3), resultado);
        }

        [Fact]
        public void ObterDataFimMais3Horas_Deve_Retornar_Fim_Mais_3_Horas()
        {
            var fim = new DateTime(2024, 3, 31, 18, 0, 0);
            var dto = new ProvaAnoDto { Fim = fim };

            var resultado = dto.ObterDataFimMais3Horas();

            Assert.Equal(fim.AddHours(3), resultado);
        }

        [Fact]
        public void ObterDataInicioDownloadMais3Horas_Deve_Retornar_InicioDownload_Mais_3_Horas_Quando_Preenchido()
        {
            var inicioDownload = new DateTime(2024, 2, 15, 6, 0, 0);
            var dto = new ProvaAnoDto { InicioDownload = inicioDownload };

            var resultado = dto.ObterDataInicioDownloadMais3Horas();

            Assert.NotNull(resultado);
            Assert.Equal(inicioDownload.AddHours(3), resultado);
        }

        [Fact]
        public void ObterDataInicioDownloadMais3Horas_Deve_Retornar_Nulo_Quando_InicioDownload_Nulo()
        {
            var dto = new ProvaAnoDto { InicioDownload = null };

            var resultado = dto.ObterDataInicioDownloadMais3Horas();

            Assert.Null(resultado);
        }

        [Fact]
        public void Deve_Aceitar_QuantidadeRespostaSincronizacao_Nula()
        {
            var dto = new ProvaAnoDto { QuantidadeRespostaSincronizacao = null };
            Assert.Null(dto.QuantidadeRespostaSincronizacao);
        }

        [Fact]
        public void Deve_Aceitar_FormatoTaiItem_Nulo()
        {
            var dto = new ProvaAnoDto { FormatoTaiItem = null };
            Assert.Null(dto.FormatoTaiItem);
        }

        [Fact]
        public void Deve_Atribuir_Todas_As_Modalidades()
        {
            foreach (var modalidade in Enum.GetValues<Modalidade>())
            {
                var dto = new ProvaAnoDto { Modalidade = modalidade };
                Assert.Equal(modalidade, dto.Modalidade);
            }
        }
    }
}