using System;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.AreaEstudante
{
    public class ObterProvasRetornoDtoTest
    {
        private ObterProvasRetornoDto CriarDtoCompleto()
        {
            return new ObterProvasRetornoDto(
                descricao: "Prova de Matemática",
                itensQuantidade: 20,
                status: 1,
                dataInicioDownload: new DateTime(2024, 1, 10),
                dataInicio: new DateTime(2024, 1, 15),
                dataFim: new DateTime(2024, 1, 20),
                id: 100,
                tempoExecucao: 60,
                tempoExtra: 10,
                tempoAlerta: 5,
                tempoTotal: 70,
                dataInicioProvaAluno: new DateTime(2024, 1, 15, 8, 0, 0),
                senha: "abc123",
                modalidade: Modalidade.Fundamental,
                dataFimProvaAluno: new DateTime(2024, 1, 15, 9, 10, 0),
                quantidadeRespostaSincronizacao: 3,
                ultimaAlteracao: new DateTime(2024, 1, 12),
                caderno: "A"
            );
        }

        [Fact]
        public void Deve_Criar_ObterProvasRetornoDto_Com_Parametros_Obrigatorios()
        {
            var dto = CriarDtoCompleto();

            Assert.Equal(100, dto.Id);
            Assert.Equal("Prova de Matemática", dto.Descricao);
            Assert.Equal(20, dto.ItensQuantidade);
            Assert.Equal(1, dto.Status);
            Assert.Equal(new DateTime(2024, 1, 10), dto.DataInicioDownload);
            Assert.Equal(new DateTime(2024, 1, 15), dto.DataInicio);
            Assert.Equal(new DateTime(2024, 1, 20), dto.DataFim);
            Assert.Equal(60, dto.TempoExecucao);
            Assert.Equal(10, dto.TempoExtra);
            Assert.Equal(5, dto.TempoAlerta);
            Assert.Equal(70, dto.TempoTotal);
            Assert.Equal(new DateTime(2024, 1, 15, 8, 0, 0), dto.DataInicioProvaAluno);
            Assert.Equal("abc123", dto.Senha);
            Assert.Equal(Modalidade.Fundamental, dto.Modalidade);
            Assert.Equal(new DateTime(2024, 1, 15, 9, 10, 0), dto.DataFimProvaAluno);
            Assert.Equal(3, dto.QuantidadeRespostaSincronizacao);
            Assert.Equal(new DateTime(2024, 1, 12), dto.UltimaAlteracao);
            Assert.Equal("A", dto.Caderno);
        }

        [Fact]
        public void Deve_Ter_Valores_Padrao_Falso_Para_Flags_Opcionais()
        {
            var dto = CriarDtoCompleto();

            Assert.False(dto.ProvaComProficiencia);
            Assert.False(dto.ApresentarResultados);
            Assert.False(dto.ApresentarResultadosPorItem);
            Assert.False(dto.FormatoTai);
            Assert.Null(dto.FormatoTaiItem);
            Assert.False(dto.FormatoTaiAvancarSemResponder);
            Assert.False(dto.FormatoTaiVoltarItemAnterior);
            Assert.False(dto.ExibirVideo);
            Assert.False(dto.ExibirAudio);
        }

        [Fact]
        public void Deve_Criar_Dto_Com_Flags_Opcionais_Ativadas()
        {
            var dto = new ObterProvasRetornoDto(
                descricao: "Prova TAI",
                itensQuantidade: 30,
                status: 1,
                dataInicioDownload: null,
                dataInicio: DateTime.Today,
                dataFim: null,
                id: 200,
                tempoExecucao: 90,
                tempoExtra: 0,
                tempoAlerta: 10,
                tempoTotal: 90,
                dataInicioProvaAluno: null,
                senha: "xyz",
                modalidade: Modalidade.Medio,
                dataFimProvaAluno: null,
                quantidadeRespostaSincronizacao: null,
                ultimaAlteracao: DateTime.Today,
                caderno: "B",
                provaComProficiencia: true,
                apresentarResultados: true,
                apresentarResultadosPorItem: true,
                formatoTai: true,
                formatoTaiItem: 55,
                formatoTaiAvancarSemResponder: true,
                formatoTaiVoltarItemAnterior: true,
                exibirVideo: true,
                exibirAudio: true
            );

            Assert.True(dto.ProvaComProficiencia);
            Assert.True(dto.ApresentarResultados);
            Assert.True(dto.ApresentarResultadosPorItem);
            Assert.True(dto.FormatoTai);
            Assert.Equal(55, dto.FormatoTaiItem);
            Assert.True(dto.FormatoTaiAvancarSemResponder);
            Assert.True(dto.FormatoTaiVoltarItemAnterior);
            Assert.True(dto.ExibirVideo);
            Assert.True(dto.ExibirAudio);
        }

        [Fact]
        public void Deve_Aceitar_Datas_Opcionais_Nulas()
        {
            var dto = new ObterProvasRetornoDto(
                descricao: "Prova",
                itensQuantidade: 10,
                status: 0,
                dataInicioDownload: null,
                dataInicio: DateTime.Today,
                dataFim: null,
                id: 1,
                tempoExecucao: 30,
                tempoExtra: 0,
                tempoAlerta: 2,
                tempoTotal: 30,
                dataInicioProvaAluno: null,
                senha: null,
                modalidade: Modalidade.Fundamental,
                dataFimProvaAluno: null,
                quantidadeRespostaSincronizacao: null,
                ultimaAlteracao: DateTime.Today,
                caderno: "C"
            );

            Assert.Null(dto.DataInicioDownload);
            Assert.Null(dto.DataFim);
            Assert.Null(dto.DataInicioProvaAluno);
            Assert.Null(dto.DataFimProvaAluno);
            Assert.Null(dto.QuantidadeRespostaSincronizacao);
            Assert.Null(dto.Senha);
        }

        [Fact]
        public void Deve_Aceitar_FormatoTaiItem_Nulo()
        {
            var dto = new ObterProvasRetornoDto(
                descricao: "Prova",
                itensQuantidade: 10,
                status: 1,
                dataInicioDownload: null,
                dataInicio: DateTime.Today,
                dataFim: null,
                id: 1,
                tempoExecucao: 30,
                tempoExtra: 0,
                tempoAlerta: 2,
                tempoTotal: 30,
                dataInicioProvaAluno: null,
                senha: "s",
                modalidade: Modalidade.Fundamental,
                dataFimProvaAluno: null,
                quantidadeRespostaSincronizacao: null,
                ultimaAlteracao: DateTime.Today,
                caderno: "D",
                formatoTaiItem: null
            );

            Assert.Null(dto.FormatoTaiItem);
        }

        [Fact]
        public void Deve_Atribuir_Modalidade_Corretamente()
        {
            var dto = new ObterProvasRetornoDto(
                descricao: "Prova EJA",
                itensQuantidade: 5,
                status: 1,
                dataInicioDownload: null,
                dataInicio: DateTime.Today,
                dataFim: null,
                id: 10,
                tempoExecucao: 60,
                tempoExtra: 0,
                tempoAlerta: 5,
                tempoTotal: 60,
                dataInicioProvaAluno: null,
                senha: "s",
                modalidade: Modalidade.EJA,
                dataFimProvaAluno: null,
                quantidadeRespostaSincronizacao: null,
                ultimaAlteracao: DateTime.Today,
                caderno: "E"
            );

            Assert.Equal(Modalidade.EJA, dto.Modalidade);
        }

        [Fact]
        public void Deve_Aceitar_QuantidadeRespostaSincronizacao_Zero()
        {
            var dto = new ObterProvasRetornoDto(
                descricao: "Prova",
                itensQuantidade: 10,
                status: 1,
                dataInicioDownload: null,
                dataInicio: DateTime.Today,
                dataFim: null,
                id: 1,
                tempoExecucao: 30,
                tempoExtra: 0,
                tempoAlerta: 2,
                tempoTotal: 30,
                dataInicioProvaAluno: null,
                senha: "s",
                modalidade: Modalidade.Fundamental,
                dataFimProvaAluno: null,
                quantidadeRespostaSincronizacao: 0,
                ultimaAlteracao: DateTime.Today,
                caderno: "F"
            );

            Assert.Equal(0, dto.QuantidadeRespostaSincronizacao);
        }
    }
}