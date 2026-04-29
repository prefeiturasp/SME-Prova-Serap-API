using System;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaAlunoAnoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaAlunoAnoDto_Com_Propriedades_Padrao()
        {
            var dto = new ProvaAlunoAnoDto();

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
            Assert.Equal(0, dto.Status);
            Assert.Null(dto.DataInicioProvaAluno);
            Assert.Null(dto.DataFimProvaAluno);
        }

        [Fact]
        public void Deve_Criar_ProvaAlunoAnoDto_Completo()
        {
            var inicio = new DateTime(2024, 3, 1);
            var fim = new DateTime(2024, 3, 31);
            var inclusao = new DateTime(2024, 1, 10);
            var inicioDownload = new DateTime(2024, 2, 20);

            var dto = new ProvaAlunoAnoDto
            {
                Id = 1,
                Descricao = "Prova de Matemática",
                InicioDownload = inicioDownload,
                Inicio = inicio,
                Fim = fim,
                TempoExecucao = 60,
                Inclusao = inclusao,
                TotalItens = 20,
                TotalCadernos = 4,
                LegadoId = 99,
                Senha = "xyz",
                PossuiBIB = true,
                Modalidade = Modalidade.Fundamental,
                Ano = "5",
                Status = 1,
                DataInicioProvaAluno = new DateTime(2024, 3, 1, 8, 0, 0),
                DataFimProvaAluno = new DateTime(2024, 3, 1, 9, 0, 0)
            };

            Assert.Equal(1, dto.Id);
            Assert.Equal("Prova de Matemática", dto.Descricao);
            Assert.Equal(inicioDownload, dto.InicioDownload);
            Assert.Equal(inicio, dto.Inicio);
            Assert.Equal(fim, dto.Fim);
            Assert.Equal(60, dto.TempoExecucao);
            Assert.Equal(inclusao, dto.Inclusao);
            Assert.Equal(20, dto.TotalItens);
            Assert.Equal(4, dto.TotalCadernos);
            Assert.Equal(99, dto.LegadoId);
            Assert.Equal("xyz", dto.Senha);
            Assert.True(dto.PossuiBIB);
            Assert.Equal(Modalidade.Fundamental, dto.Modalidade);
            Assert.Equal("5", dto.Ano);
            Assert.Equal(1, dto.Status);
            Assert.Equal(new DateTime(2024, 3, 1, 8, 0, 0), dto.DataInicioProvaAluno);
            Assert.Equal(new DateTime(2024, 3, 1, 9, 0, 0), dto.DataFimProvaAluno);
        }

        [Fact]
        public void Deve_Aceitar_InicioDownload_Nulo()
        {
            var dto = new ProvaAlunoAnoDto { InicioDownload = null };
            Assert.Null(dto.InicioDownload);
        }

        [Fact]
        public void Deve_Aceitar_DataInicioProvaAluno_Nula()
        {
            var dto = new ProvaAlunoAnoDto { DataInicioProvaAluno = null };
            Assert.Null(dto.DataInicioProvaAluno);
        }

        [Fact]
        public void Deve_Aceitar_DataFimProvaAluno_Nula()
        {
            var dto = new ProvaAlunoAnoDto { DataFimProvaAluno = null };
            Assert.Null(dto.DataFimProvaAluno);
        }

        [Fact]
        public void Deve_Atribuir_Todas_As_Modalidades()
        {
            foreach (var modalidade in Enum.GetValues<Modalidade>())
            {
                var dto = new ProvaAlunoAnoDto { Modalidade = modalidade };
                Assert.Equal(modalidade, dto.Modalidade);
            }
        }

        [Fact]
        public void Deve_Aceitar_PossuiBIB_Falso()
        {
            var dto = new ProvaAlunoAnoDto { PossuiBIB = false };
            Assert.False(dto.PossuiBIB);
        }
    }
}